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

		private PeriodPriceService periodPriceService = new PeriodPriceService();

		private AccommodationUnitTypeService unitTypeService = new AccommodationUnitTypeService();

		public List<AccommodationUnit> GetAccommodationUnits(long accommodationId)
		{
			unitTypeService.GetAccommodationUnitTypes();

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
						unitDB.Deleted = false;
					}
					else
					{
						unit.Accommodation = unitOfWork.Accommodations.Find(a => a.Id == accommodationId).First();
						unit.AccommodationUnitType = unitOfWork.AccommodationUnitTypes.SingleOrDefault(ut => ut.Id == unit.AccommodationUnitType.Id);
						unitOfWork.AccommodationUnits.Add(unit);
					}

					unitOfWork.Complete();
					periodPriceService.GetPeriodPrices(unit.Id);
				}

				//set deleted units in localDB
				List<AccommodationUnit> unitsDB = unitOfWork.AccommodationUnits.Find(au => au.Accommodation.Id == accommodationId).ToList();
				foreach (AccommodationUnit unitDB in unitsDB)
				{
					int flag = 0;
					foreach (AccommodationUnit unit in units)
					{
						if (unit.Id == unitDB.Id)
							flag += 1;
					}
					if (flag == 0)
					{
						unitDB.Deleted = true;
						unitOfWork.Complete();
					}
				}
			}
			catch
			{
			}
			return unitOfWork.AccommodationUnits.Find(au => au.Accommodation.Id == accommodationId && !au.Deleted).ToList();
;		}
		
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
