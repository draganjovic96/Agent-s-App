using Agent_s_App.AccommodationServiceServiceReference;
using Agent_s_App.Core.Model;
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
	public class AccommodationServiceService
	{

		private UnitOfWork unitOfWork = new UnitOfWork(MainWindow.context);

		private ServicePortClient servicePortClient = new ServicePortClient();

		public List<Core.Model.AccommodationService> GetAllAccommodationServices(long accommodationId)
		{
			GetServicesRequestDTO getServicesRequestDTO = new GetServicesRequestDTO();
			try
			{	
				GetServicesResponseDTO getServicesResponseDTO = new GetServicesResponseDTO(servicePortClient.getServices(getServicesRequestDTO.GetServicesRequest));

				//Add and update services in localDB
				foreach (Core.Model.AccommodationService accommodationService in getServicesResponseDTO.AccommodationServices)
				{
					Core.Model.AccommodationService serviceDB = unitOfWork.AccommodationServices.SingleOrDefault(s => s.Id == accommodationService.Id);
					if (serviceDB != null)
					{
						serviceDB.Name = accommodationService.Name;
						serviceDB.Description = accommodationService.Description;
						serviceDB.Deleted = false;
					}
					else
					{
						unitOfWork.AccommodationServices.Add(accommodationService);
					}
					unitOfWork.Complete();
				}					
				GetAccommodationServices(accommodationId);

				//Set service deleted in localDB
				foreach (Core.Model.AccommodationService accommodateionServiceDB in unitOfWork.AccommodationServices.GetAll().ToList())
				{
					int flag = 0;
					foreach (Core.Model.AccommodationService accommodationService in getServicesResponseDTO.AccommodationServices)
					{
						if (accommodateionServiceDB.Id == accommodationService.Id)
							flag += 1;
					}
					if (flag == 0)
					{
						accommodateionServiceDB.Deleted = true;
					}
					unitOfWork.Complete();
				}

				return unitOfWork.AccommodationServices.Find(s => s.Deleted == false).ToList();
			}
			catch
			{
				return new List<Core.Model.AccommodationService>();
			}
		}

		public void GetAccommodationServices(long accommodationId)
		{
			GetAccommodationServicesRequestDTO getAccommodationServicesRequestDTO = new GetAccommodationServicesRequestDTO(accommodationId);
			try
			{
				GetAccommodationServicesResponseDTO getAccommodationServicesResponseDTO = new GetAccommodationServicesResponseDTO(servicePortClient.getAccommodationServices(getAccommodationServicesRequestDTO.GetAccommodationServicesRequest));
				Accommodation accommodationDB = unitOfWork.Accommodations.SingleOrDefault(a => a.Id == accommodationId);

				foreach (Core.Model.AccommodationService accommodationServiceDB in unitOfWork.AccommodationServices.GetAll())
				{
					int flag = 0;
					foreach (Core.Model.AccommodationService accommodationService in getAccommodationServicesResponseDTO.AccommodationServices)
					{
						if (accommodationService.Id == accommodationServiceDB.Id)
						{
							flag +=1;
						}
					}
					if (flag != 0)
						accommodationServiceDB.Accommodations.Add(accommodationDB);
					else
						accommodationServiceDB.Accommodations.Remove(accommodationDB);
					unitOfWork.Complete();
				}

			}
			catch
			{
			}
		}

		public List<Accommodation> GetServiceAccommodations(long serviceId)
		{
			Core.Model.AccommodationService service = unitOfWork.AccommodationServices.Find(s => s.Id == serviceId).First();
			return service.Accommodations.ToList();
		}

		public bool SaveAffiliation(long accommodationId, bool parameter, long serviceId)
		{
			if (parameter)
			{ 
			try
			{
				AddServiceToAccommodationRequestDTO addServiceToAccommodationRequestDTO = new AddServiceToAccommodationRequestDTO(accommodationId, serviceId);
				AddServiceToAccommodationResponseDTO addServiceToAccommodationResponseDTO = new AddServiceToAccommodationResponseDTO(servicePortClient.addAccommodationService(addServiceToAccommodationRequestDTO.AddAccommodationServiceRequest));
				Core.Model.AccommodationService serviceDB = unitOfWork.AccommodationServices.SingleOrDefault(s => s.Id == serviceId);
				Accommodation accommodationDB = unitOfWork.Accommodations.SingleOrDefault(a => a.Id == accommodationId);
				serviceDB.Accommodations.Add(accommodationDB);
				unitOfWork.Complete();
				return true;
			}
			catch
			{
				return false;
			}
			}
			else
			{
				try
				{
					RemoveServiceFromAccommodationRequestDTO removeServiceFromAccommodationRequestDTO = new RemoveServiceFromAccommodationRequestDTO(accommodationId, serviceId);
					servicePortClient.removeAccommodationService(removeServiceFromAccommodationRequestDTO.RemoveAccommodationServiceRequest);
					Core.Model.AccommodationService serviceDB = unitOfWork.AccommodationServices.SingleOrDefault(s => s.Id == serviceId);
					Accommodation accommodationDB = unitOfWork.Accommodations.SingleOrDefault(a => a.Id == accommodationId);
					serviceDB.Accommodations.Remove(accommodationDB);
					unitOfWork.Complete();
					return true;
				}
				catch
				{
					return false;
				}
			}
		}

		public bool AddService(Core.Model.AccommodationService service)
		{
			AddServiceRequestDTO addServiceRequestDTO = new AddServiceRequestDTO(service);
			AddServiceResponseDTO addServiceResponseDTO = new AddServiceResponseDTO(servicePortClient.addService(addServiceRequestDTO.AddServiceRequest));
			if (addServiceResponseDTO.AccommodationService.Id != 0)
				 return true; 
			else
				return false;
		}

		public bool UpdateService(Core.Model.AccommodationService service)
		{
			try
			{
				UpdateServiceRequestDTO updateServiceRequestDTO = new UpdateServiceRequestDTO(service);
				servicePortClient.updateService(updateServiceRequestDTO.UpdateServiceRequest);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool DeleteService(long serviceId)
		{
			try
			{
				DeleteServiceRequestDTO deleteServiceRequestDTO = new DeleteServiceRequestDTO(serviceId);
				servicePortClient.removeService(deleteServiceRequestDTO.RemoveServiceRequest);
				return true;
			}
			catch
			{
				return false;
			}
		}

	}
}
