using Agent_s_App.AccommodationServiceServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class RemoveServiceFromAccommodationRequestDTO
	{
		public removeAccommodationServiceRequest RemoveAccommodationServiceRequest { get; set; }

		public RemoveServiceFromAccommodationRequestDTO(long accommodationId, long serviceId)
		{
			RemoveAccommodationServiceRequest = new removeAccommodationServiceRequest()
			{
				accommodationId = accommodationId,
				accommodationServiceId = serviceId
			};
		}
	}
}
