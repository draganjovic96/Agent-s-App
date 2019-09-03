using Agent_s_App.AccommodationServiceServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class GetServicesRequestDTO
	{
		public getServicesRequest GetServicesRequest { get; set; }

		public GetServicesRequestDTO()
		{
			GetServicesRequest = new getServicesRequest();
		}
	}
}
