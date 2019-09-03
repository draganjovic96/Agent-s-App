using Agent_s_App.AccommodationUnitTypeServiceReference;
using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ResponseDTO
{
	public class GetUnitTypesResponseDTO
	{
		public List<AccommodationUnitType> AccommodationUnitTypes { get; set; }

		public GetUnitTypesResponseDTO(getAccommodationUnitTypesResponse getAccommodationUnitTypesResponse)
		{
			AccommodationUnitTypes = new List<AccommodationUnitType>();

			foreach (accommodationUnitType unitType in getAccommodationUnitTypesResponse.accommodationUnitTypes.ToList())
			{
				AccommodationUnitType accommodationUnitType = new AccommodationUnitType()
				{
					Id = unitType.Id,
					Name = unitType.Name
				};
				AccommodationUnitTypes.Add(accommodationUnitType);
			}
		}
	}
}
