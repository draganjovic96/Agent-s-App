using Agent_s_App.AccommodationServiceServiceReference;
using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ResponseDTO
{
	public class AddServiceToAccommodationResponseDTO
	{
		public AccommodationService AccommodationService { get; set; }

		public AddServiceToAccommodationResponseDTO(addAccommodationServiceResponse addAccommodationServiceResponse)
		{
			AccommodationService = new AccommodationService()
			{
				Id = addAccommodationServiceResponse.service.Id
			};
		}
	}
}
