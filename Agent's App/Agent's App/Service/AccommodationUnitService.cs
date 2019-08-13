using Agent_s_App.AccommodationUnitServiceReference;
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
	public class AccommodationUnitService
	{
		private readonly UnitOfWork unitOfWork = new UnitOfWork(MainWindow.context);

		private AccommodationUnitPortClient accommodationUnitPortClient = new AccommodationUnitPortClient();

		public List<AccommodationUnit> GetAccommodationUnits(long accommodationId)
		{
			try
			{
				GetUnitsRequestDTO getUnitsRequestDTO = new GetUnitsRequestDTO(accommodationId);
				GetUnitsResponseDTO getUnitsResponseDTO = new GetUnitsResponseDTO(accommodationUnitPortClient.getAccommodationUnits(getUnitsRequestDTO.GetAccommodationUnitsRequest));
				List<AccommodationUnit> units = getUnitsResponseDTO.AccommodationUnits;

				foreach (AccommodationUnit unit in units)
				{
					AccommodationUnit unitDB = unitOfWork.AccommodationUnits.SingleOrDefault(au => au.Id == unit.Id);
					if (unitDB != null)
					{
						unitDB.Number = unit.Number;
						unitDB.NumberOfBeds = unit.NumberOfBeds;
						unitDB.Floor = unit.Floor;
						unitDB.DefaultPrice = unit.DefaultPrice;
						unitDB.AccommodationUnitType = unitOfWork.AccommodationUnitTypes.SingleOrDefault(ut => ut.Id == unit.AccommodationUnitType.Id);
						
					}
					else
					{
						unit.Accommodation = unitOfWork.Accommodations.Find(a => a.Id == accommodationId).First();
						AccommodationUnitType unitType = unitOfWork.AccommodationUnitTypes.SingleOrDefault(ut => ut.Id == unit.AccommodationUnitType.Id);
						if (unitType != null)
							unit.AccommodationUnitType = unitType;
						unitOfWork.AccommodationUnits.Add(unit);

					}

					unitOfWork.Complete();
				}
				return units;
			}
			catch
			{
				return new List<AccommodationUnit>();
			}
		}
		
		public void AddAccommodationUnit(AccommodationUnit accommodationUnit, long accommodationId)
		{
			AddUnitRequestDTO addUnitRequestDTO = new AddUnitRequestDTO(accommodationUnit, accommodationId);
			accommodationUnitPortClient.addAccommodationUnit(addUnitRequestDTO.AddAccommodationUnitRequest);
		}

		public void UpdateAccommodationUnit(AccommodationUnit accommodationUnit)
		{
			UpdateUnitRequestDTO updateUnitRequestDTO = new UpdateUnitRequestDTO(accommodationUnit);
			accommodationUnitPortClient.updateAccommodationUnit(updateUnitRequestDTO.UpdateAccommodationUnitRequest);
		}

		public void DeleteAccommodationUnit(long accommodationUnitId)
		{
			DeleteUnitRequestDTO deleteUnitRequestDTO = new DeleteUnitRequestDTO(accommodationUnitId);
			accommodationUnitPortClient.removeAccommodationUnit(deleteUnitRequestDTO.RemoveAccommodationUnitRequest);
		}
	}
}
