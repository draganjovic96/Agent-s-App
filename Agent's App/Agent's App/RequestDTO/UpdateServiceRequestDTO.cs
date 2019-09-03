using Agent_s_App.AccommodationServiceServiceReference;
using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class UpdateServiceRequestDTO
	{
		public updateServiceRequest UpdateServiceRequest { get; set; }

		public UpdateServiceRequestDTO(AccommodationService accommodationService)
		{
			UpdateServiceRequest = new updateServiceRequest()
			{
				service = new service()
				{
					Id = accommodationService.Id,
					Name = accommodationService.Name,
					Description = accommodationService.Description
				}
			};
		}
	}
}
