using Agent_s_App.AccommodationUnitServiceReference;
using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ResponseDTO
{
	public class GetUnitsResponseDTO
	{
		public List<AccommodationUnit> AccommodationUnits { get; set; }

		public GetUnitsResponseDTO(getAccommodationUnitsResponse getAccommodationUnitResponse)
		{
			AccommodationUnits = new List<AccommodationUnit>();
			foreach (accommodationUnit unitResponse in getAccommodationUnitResponse.accommodationUnits.ToList())
			{
				AccommodationUnit unit = new AccommodationUnit()
				{
					Id = unitResponse.Id,
					DefaultPrice = unitResponse.DefaultPrice,
					Floor = unitResponse.Floor,
					Number = unitResponse.Number,
					NumberOfBeds = unitResponse.NumberOfBeds,
					AccommodationUnitType = new AccommodationUnitType()
					{
						Id = unitResponse.AccommodationUnitType.Id
					}
				};
				AccommodationUnits.Add(unit);
			}
		}
	}
}
