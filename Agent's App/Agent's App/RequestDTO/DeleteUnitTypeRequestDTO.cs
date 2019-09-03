using Agent_s_App.AccommodationUnitTypeServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class DeleteUnitTypeRequestDTO
	{
		public removeAccommodationUnitTypeRequest RemoveAccommodationUnitTypeRequest { get; set; }

		public DeleteUnitTypeRequestDTO(long unitTypeId)
		{
			RemoveAccommodationUnitTypeRequest = new removeAccommodationUnitTypeRequest()
			{
				accommodationUnitTypeId = unitTypeId
			};
		}
	}
}
