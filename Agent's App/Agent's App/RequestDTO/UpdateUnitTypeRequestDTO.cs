using Agent_s_App.AccommodationUnitTypeServiceReference;
using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class UpdateUnitTypeRequestDTO
	{
		public updateAccommodationUnitTypeRequest UpdateAccommodationUnitTypeRequest { get; set; }

		public UpdateUnitTypeRequestDTO(AccommodationUnitType AccommodationUnitType)
		{
			UpdateAccommodationUnitTypeRequest = new updateAccommodationUnitTypeRequest()
			{
				accommodationUnitType = new accommodationUnitType()
				{
					Id = AccommodationUnitType.Id,
					Name = AccommodationUnitType.Name
				}
			};
		}
	}
}
