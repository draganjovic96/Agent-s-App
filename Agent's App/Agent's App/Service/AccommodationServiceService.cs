using Agent_s_App.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Service
{
	public class AccommodationServiceService
	{
		private UnitOfWork unitOfWork = new UnitOfWork(MainWindow.context);

		public List<Core.Model.AccommodationService> GetAllAccommodationServices()
		{
			return unitOfWork.AccommodationServices.GetAll().ToList();
		}

		public List<Core.Model.AccommodationService> GetAccommodationServices(long accommodationId)
		{
			return unitOfWork.AccommodationServices.Find(s => s.Accommodations.Any(a => a.Id == accommodationId)).ToList();
		}
	}
}
