using Agent_s_App.AccommodationUnitTypeServiceReference;
using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class AddUnitTypeRequestDTO
	{
		public addAccommodationUnitTypeRequest AddAccommodationUnitTypeRequest { get; set; }

		public AddUnitTypeRequestDTO(AccommodationUnitType unitType)
		{
			AddAccommodationUnitTypeRequest = new addAccommodationUnitTypeRequest() {
				accommodationUnitType = new accommodationUnitType()
				{
					Name = unitType.Name
				}
			};
		}
	}
}
