using Agent_s_App.ReservationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class GetUnitReservationsRequestDTO
	{
		public getReservationsByUnitRequest GetReservationsByUnitRequest { get; set; }

		public GetUnitReservationsRequestDTO(long unitId)
		{
			GetReservationsByUnitRequest = new getReservationsByUnitRequest()
			{
				unitId = unitId
			};
		}
	}
}
