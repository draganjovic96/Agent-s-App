using Agent_s_App.AccommodationServiceServiceReference;
using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ResponseDTO
{
	public class GetAccommodationServicesResponseDTO
	{
		public List<AccommodationService> AccommodationServices { get; set; }

		public GetAccommodationServicesResponseDTO(getAccommodationServicesResponse getAccommodationServicesResponse)
		{
			AccommodationServices = new List<AccommodationService>();
			foreach(service service in getAccommodationServicesResponse.services)
			{
				AccommodationService accommodationService = new AccommodationService()
				{
					Id = service.Id
				};
				AccommodationServices.Add(accommodationService);
			}
		}
	}
}
