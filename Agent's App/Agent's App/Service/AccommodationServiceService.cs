using Agent_s_App.Core.Model;
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

		public List<Accommodation> GetServiceAccommodations(long serviceId)
		{
			Core.Model.AccommodationService service = unitOfWork.AccommodationServices.Find(s => s.Id == serviceId).First();
			return service.Accommodations.ToList();
		}

		public void SaveAffiliation(Accommodation accommodation, bool parameter, long serviceId)
		{
			Core.Model.AccommodationService service = unitOfWork.AccommodationServices.Find(s => s.Id == serviceId).First();
			if (parameter) service.Accommodations.Add(accommodation);
			else service.Accommodations.Remove(accommodation);
			unitOfWork.AccommodationServices.Add(service);
			unitOfWork.Complete();
		}

		public void AddService(Core.Model.AccommodationService service)
		{
			unitOfWork.AccommodationServices.Add(service);
			unitOfWork.Complete();
		}

		public void DeleteService(Core.Model.AccommodationService service)
		{
			unitOfWork.AccommodationServices.Remove(service);
			unitOfWork.Complete();
		}

	}
}
