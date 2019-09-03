using Agent_s_App.AccommodationServiceServiceReference;
using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class AddServiceRequestDTO
	{
		public addServiceRequest AddServiceRequest { get; set; }

		public AddServiceRequestDTO(AccommodationService accommodationService)
		{
			AddServiceRequest = new addServiceRequest()
			{
				service = new service()
				{
					Name = accommodationService.Name,
					Description = accommodationService.Description
				}
			};
		}
	}
}
