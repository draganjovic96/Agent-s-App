using Agent_s_App.AccommodationUnitServiceReference;
using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
    public class AddUnitRequestDTO
    {
		public addAccommodationUnitRequest AddAccommodationUnitRequest { get; set; }

		public AddUnitRequestDTO(AccommodationUnit unit, long accommodationId)
		{
			AddAccommodationUnitRequest = new addAccommodationUnitRequest()
			{
				accommodationId = accommodationId,
				accommodationUnit = new accommodationUnit()
				{
					Floor = unit.Floor,
					Number = unit.Number,
					NumberOfBeds = unit.NumberOfBeds,
					DefaultPrice = unit.DefaultPrice,
					AccommodationUnitType = new accommodationUnitType()
					{
						Id = unit.AccommodationUnitType.Id
					}
				}
			};
		}
	}
}
