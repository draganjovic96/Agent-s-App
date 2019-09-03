using Agent_s_App.Core.Model;
using Agent_s_App.ReservationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class AddReservationRequestDTO
	{
		public addReservationRequest AddReservationRequest { get; set; }

		public AddReservationRequestDTO(Reservation reservationToAdd)
		{
			AddReservationRequest = new addReservationRequest()
			{
				reservation = new reservation()
				{
					fromDate = reservationToAdd.FromDate,
					toDate = reservationToAdd.ToDate,
					guest = new user()
					{
						Id = reservationToAdd.Guest.Id,
						Username = reservationToAdd.Guest.Username
					},
					accommodationUnit = new accommodationUnit()
					{
						Id = reservationToAdd.AccommodationUnit.Id
					},
				}
			};
		}
	}
}
