using Agent_s_App.ReservationServiceReference;
using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ResponseDTO
{
	public class GetUnitReservationsResponseDTO
	{
		public long UnitId { get; set; }

		public List<Reservation> Reservations { get; set; }

		public GetUnitReservationsResponseDTO(getReservationsByUnitResponse reservationsByUnitResponse)
		{
			UnitId = reservationsByUnitResponse.unitId;

			Reservations = new List<Reservation>();
			if (reservationsByUnitResponse.reservations != null)
			{
				foreach (reservation reservationResponse in reservationsByUnitResponse.reservations)
				{
					Reservation reservation = new Reservation()
					{
						Id = reservationResponse.id,
						FromDate = reservationResponse.fromDate,
						ToDate = reservationResponse.toDate,
						AgentConfirmed = reservationResponse.agentConfirmed,
						Confirmed = reservationResponse.confirmed,
						Price = reservationResponse.price,
						Guest = new User()
						{
							Username = reservationResponse.guest.Username
						}
					};
					if (reservationResponse.commentRate != null)
					{
						reservation.CommentRate = new CommentRate()
						{
							Id = reservationResponse.commentRate.id,
							Ocena = reservationResponse.commentRate.ocena,
							CommentDateTime = reservationResponse.commentRate.commentDate,
							ApprovedComment = reservationResponse.commentRate.approvedComment,
							ContentOfComment = reservationResponse.commentRate.contentOfComment
						};
					}
					Reservations.Add(reservation);
				}
			}
		}
	}
}
