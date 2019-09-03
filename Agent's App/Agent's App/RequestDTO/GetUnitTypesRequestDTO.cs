using Agent_s_App.AccommodationUnitTypeServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class GetUnitTypesRequestDTO
	{
		public getAccommodationUnitTypesRequest GetAccommodationUnitTypesRequest { get; set; }

		public GetUnitTypesRequestDTO()
		{
			GetAccommodationUnitTypesRequest = new getAccommodationUnitTypesRequest();
		}
	}
}
