using Agent_s_App.Core.Model;
using Agent_s_App.ReservationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class UpdateReservationRequestDTO
	{
		public updateReservationRequest UpdateReservationRequest { get; set; }

		public UpdateReservationRequestDTO(Reservation reservationToUpdate)
		{
			UpdateReservationRequest = new updateReservationRequest()
			{
				reservation = new reservation()
				{
					id = reservationToUpdate.Id,
					toDate = reservationToUpdate.ToDate,
					fromDate = reservationToUpdate.FromDate,
					agentConfirmed = reservationToUpdate.AgentConfirmed
				}
			};
		}
	}
}
