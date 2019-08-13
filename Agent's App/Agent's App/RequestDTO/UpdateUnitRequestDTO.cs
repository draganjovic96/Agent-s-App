using Agent_s_App.AccommodationUnitServiceReference;
using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class UpdateUnitRequestDTO
	{
		public updateAccommodationUnitRequest UpdateAccommodationUnitRequest { get; set; }

		public UpdateUnitRequestDTO(AccommodationUnit unit)
		{
			UpdateAccommodationUnitRequest = new updateAccommodationUnitRequest()
			{
				accommodationUnit = new accommodationUnit()
				{
					Id = unit.Id,
					Floor = unit.Floor,
					Number = unit.Number,
					NumberOfBeds = unit.NumberOfBeds,
					DefaultPrice = unit.DefaultPrice,
					AccommodationUnitType = new accommodationUnitType()
					{
						Id = unit.AccommodationUnitType.Id
					},
					Accommodation = new accommodation()
					{
						Id = unit.Accommodation.Id
					}
				}
			};
		}
	}
}
