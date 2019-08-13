using Agent_s_App.AccommodationUnitServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class DeleteUnitRequestDTO
	{
		public removeAccommodationUnitRequest RemoveAccommodationUnitRequest { get; set; }

		public DeleteUnitRequestDTO(long unitId)
		{
			RemoveAccommodationUnitRequest = new removeAccommodationUnitRequest()
			{
				accommodationUnitId = unitId
			};
		}
	}
}
