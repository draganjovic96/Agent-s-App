using Agent_s_App.Core.Model;
using Agent_s_App.Persistance;
using Agent_s_App.Persistance.Repository;
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

		public List<AccommodationUnitType> GetAccommodationUnitTypes(long accommodationId)
		{
			return unitOfWork.AccommodationUnitTypes.GetAll().ToList();
		}

		public void AddAccommodationUnitType(AccommodationUnitType accommodationUnitType)
		{
			unitOfWork.AccommodationUnitTypes.Add(accommodationUnitType);
			unitOfWork.Complete();
		}

		public void DeleteAccommodationUnitType(AccommodationUnitType accommodationUnitType)
		{
			unitOfWork.AccommodationUnitTypes.Remove(accommodationUnitType);
			unitOfWork.Complete();
		}
    }
}
