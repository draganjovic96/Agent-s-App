using Agent_s_App.AccommodationUnitServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class GetUnitsRequestDTO
	{
		public getAccommodationUnitsRequest GetAccommodationUnitsRequest { get; set; }

		public GetUnitsRequestDTO(long Id)
		{
			GetAccommodationUnitsRequest = new getAccommodationUnitsRequest()
			{
				id = Id
			};
		}
	}
}
