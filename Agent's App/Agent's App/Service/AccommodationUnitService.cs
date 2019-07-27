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
	public class AccommodationUnitService
	{
		private readonly UnitOfWork unitOfWork = new UnitOfWork(MainWindow.context);

		public List<AccommodationUnit> GetAccommodationUnits(long accommodationId)
		{
			return unitOfWork.AccommodationUnits.Find(x => x.Accommodation.Id == accommodationId).ToList();
		}

		public AccommodationUnit GetAccommodationUnit(long unitId)
		{
			return unitOfWork.AccommodationUnits.Find(x => x.Id == unitId).First();
		}

		public void AddAccommodationUnit(AccommodationUnit accommodationUnit)
		{
			unitOfWork.AccommodationUnits.Add(accommodationUnit);
			unitOfWork.Complete();
		}

		public void DeleteAccommodationUnit(AccommodationUnit accommodationUnit)
		{
			unitOfWork.AccommodationUnits.Remove(accommodationUnit);
			unitOfWork.Complete();
		}
	}
}
