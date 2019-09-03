using Agent_s_App.AccommodationServiceServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class GetAccommodationServicesRequestDTO
	{
		public getAccommodationServicesRequest GetAccommodationServicesRequest { get; set; }

		public GetAccommodationServicesRequestDTO(long AccommodationId)
		{
			GetAccommodationServicesRequest = new getAccommodationServicesRequest()
			{
				accommodationId = AccommodationId
			};
		}
	}
}
