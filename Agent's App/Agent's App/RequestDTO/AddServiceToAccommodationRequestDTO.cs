using Agent_s_App.AccommodationServiceServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class AddServiceToAccommodationRequestDTO
	{
		public addAccommodationServiceRequest AddAccommodationServiceRequest { get; set; }

		public AddServiceToAccommodationRequestDTO(long accommodationId, long serviceId)
		{
			AddAccommodationServiceRequest = new addAccommodationServiceRequest()
			{
				accommodationId = accommodationId,
				serviceId = serviceId,
				service = new service()
				{
					Id = serviceId
				}
			};
		}
	}
}
