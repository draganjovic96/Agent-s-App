using Agent_s_App.AccommodationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class GetAccommodationRequestDTO
	{
		public getAccommodationByUserRequest getAccommodationByUserRequest { get; set; }

		public GetAccommodationRequestDTO(string Username)
		{
			getAccommodationByUserRequest = new getAccommodationByUserRequest()
			{
				username = Username,
			};
		}

	}
}
