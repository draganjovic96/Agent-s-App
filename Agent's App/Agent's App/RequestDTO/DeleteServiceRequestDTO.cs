using Agent_s_App.AccommodationServiceServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class DeleteServiceRequestDTO
	{
		public removeServiceRequest RemoveServiceRequest { get; set; }

		public DeleteServiceRequestDTO(long serviceId)
		{
			RemoveServiceRequest = new removeServiceRequest()
			{
				serviceId = serviceId
			};
		}
	}
}
