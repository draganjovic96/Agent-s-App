using Agent_s_App.AccommodationServiceServiceReference;
using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ResponseDTO
{
	public class GetServicesResponseDTO
	{
		public List<AccommodationService> AccommodationServices { get; set; }

		public GetServicesResponseDTO(getServicesResponse GetServicesResponse)
		{
			AccommodationServices = new List<AccommodationService>();
			foreach (service service in GetServicesResponse.services)
			{
				AccommodationService accommodationService = new AccommodationService()
				{
					Id = service.Id,
					Name = service.Name,
					Description = service.Description
				};
				AccommodationServices.Add(accommodationService);
			}
		}
	}
}
