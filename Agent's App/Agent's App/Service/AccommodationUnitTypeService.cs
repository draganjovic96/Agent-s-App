using Agent_s_App.AccommodationUnitTypeServiceReference;
using Agent_s_App.Core.Model;
using Agent_s_App.Persistance;
using Agent_s_App.Persistance.Repository;
using Agent_s_App.RequestDTO;
using Agent_s_App.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Service
{
    public class AccommodationUnitTypeService
    {
		private UnitOfWork unitOfWork = new UnitOfWork(MainWindow.context);

		private AccommodationUnitTypePortClient accommodationUnitTypePortClient = new AccommodationUnitTypePortClient();

		public List<AccommodationUnitType> GetAccommodationUnitTypes()
		{
			GetUnitTypesRequestDTO getUnitTypesRequestDTO = new GetUnitTypesRequestDTO();
			GetUnitTypesResponseDTO getUnitTypesResponseDTO = new GetUnitTypesResponseDTO(accommodationUnitTypePortClient.getAccommodationUnitTypes(getUnitTypesRequestDTO.GetAccommodationUnitTypesRequest));
			List<AccommodationUnitType> types = getUnitTypesResponseDTO.AccommodationUnitTypes;
			foreach (AccommodationUnitType unitType in types)
			{
				AccommodationUnitType unitTypeDB = unitOfWork.AccommodationUnitTypes.SingleOrDefault(ut => ut.Id == unitType.Id);
				if (unitTypeDB != null)
				{
					unitTypeDB.Name = unitType.Name;
					unitTypeDB.Deleted = false;
				}
				else
				{
					unitOfWork.AccommodationUnitTypes.Add(unitType);
				}
				unitOfWork.Complete();
			}

			//Set deleted types in localDB
			List<AccommodationUnitType> typesDB = unitOfWork.AccommodationUnitTypes.GetAll().ToList();
			foreach (AccommodationUnitType typeDB in typesDB)
			{
				int flag = 0;
				foreach (AccommodationUnitType unitType in types)
				{
					if (typeDB.Id == unitType.Id)
						flag += 1;
				}

				if (flag == 0)
				{
					typeDB.Deleted = true;
					unitOfWork.Complete();
				}
			}
			return unitOfWork.AccommodationUnitTypes.Find(t => !t.Deleted).ToList();
		}

		public void AddAccommodationUnitType(AccommodationUnitType accommodationUnitType)
		{
			AddUnitTypeRequestDTO addUnitTypeRequestDTO = new AddUnitTypeRequestDTO(accommodationUnitType);
			accommodationUnitTypePortClient.addAccommodationUnitType(addUnitTypeRequestDTO.AddAccommodationUnitTypeRequest);
		}

		public void UpdateAccommodationUnitType(AccommodationUnitType accommodationUnitType)
		{
			UpdateUnitTypeRequestDTO updateUnitTypeRequestDTO = new UpdateUnitTypeRequestDTO(accommodationUnitType);
			accommodationUnitTypePortClient.updateAccommodationUnitType(updateUnitTypeRequestDTO.UpdateAccommodationUnitTypeRequest);
		}

		public bool DeleteAccommodationUnitType(long accommodationUnitTypeId)
		{
			try
			{
				DeleteUnitTypeRequestDTO deleteUnitTypeRequestDTO = new DeleteUnitTypeRequestDTO(accommodationUnitTypeId);
				accommodationUnitTypePortClient.removeAccommodationUnitType(deleteUnitTypeRequestDTO.RemoveAccommodationUnitTypeRequest);
				return true;
			}
			catch
			{
				return false;
			}
		}
    }
}
