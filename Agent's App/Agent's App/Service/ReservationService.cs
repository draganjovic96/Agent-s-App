using Agent_s_App.Core.Model;
using Agent_s_App.Persistance.Repository;
using Agent_s_App.RequestDTO;
using Agent_s_App.ReservationServiceReference;
using Agent_s_App.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Service
{
	public class ReservationService
	{
		private readonly UnitOfWork unitOfWork = new UnitOfWork(MainWindow.context);

		private ReservationPortClient reservationPortClient = new ReservationPortClient();

		private UserServiceReference.MojuserPortClient userPortClient = new UserServiceReference.MojuserPortClient();

		public List<Reservation> GetReservations(long accommodationUnitId, long accommodationId)
		{

			if (accommodationUnitId == 0)
			{
				List<AccommodationUnit> accommodationUnits = unitOfWork.AccommodationUnits.Find(u => u.Accommodation.Id == accommodationId).ToList();
				foreach (AccommodationUnit unit in accommodationUnits)
				{
					GetUnitReservationsRequestDTO getUnitReservationsRequestDTO = new GetUnitReservationsRequestDTO(unit.Id);
					try
					{
						GetUnitReservationsResponseDTO getUnitReservationsResponseDTO = new GetUnitReservationsResponseDTO(reservationPortClient.getReservationsByUnit(getUnitReservationsRequestDTO.GetReservationsByUnitRequest));
						if (getUnitReservationsResponseDTO.Reservations.Count > 0)
						{
							foreach (Reservation reservation in getUnitReservationsResponseDTO.Reservations)
							{
								GetUserRequestDTO getUserRequestDTO = new GetUserRequestDTO(reservation.Guest.Username);
								GetUserResponseDTO getUserResponseDTO = new GetUserResponseDTO(userPortClient.getUsers(getUserRequestDTO.GetUsersRequest), reservation.Guest.Username);

								//first add user in local DB and then set it as guest in reservation
								User user = getUserResponseDTO.User;
								User userDB = unitOfWork.Users.SingleOrDefault(u => u.Id == user.Id);
								if (userDB != null)
								{
									//update user in local DB
									userDB = user;
									userDB.Name = user.Name;
									userDB.LastName = user.LastName;
									userDB.Password = user.Password;
									userDB.Blocked = user.Blocked;
									userDB.Deleted = user.Deleted;
								}
								else
								{
									unitOfWork.Users.Add(user);
								}

								unitOfWork.Complete();

								//add reservation in local DB
								Reservation reservationDB = unitOfWork.Reservations.SingleOrDefault(r => r.Id == reservation.Id);
								if (reservationDB != null)
								{
									//update reservation in local DB
									if (reservationDB.CommentRate == null)
										reservationDB.CommentRate = reservation.CommentRate;
									else
									{
										reservationDB.CommentRate.ApprovedComment = reservation.CommentRate.ApprovedComment;
									}
									reservationDB.Confirmed = reservation.Confirmed;
									reservationDB.FromDate = reservation.FromDate;
									reservationDB.ToDate = reservation.ToDate;
									reservationDB.AgentConfirmed = reservation.AgentConfirmed;
									reservationDB.Price = reservation.Price;
								}
								else
								{
									reservation.AccommodationUnit = unitOfWork.AccommodationUnits.Get(getUnitReservationsResponseDTO.UnitId);
									reservation.Guest = unitOfWork.Users.SingleOrDefault(u => u.Username == reservation.Guest.Username);
									unitOfWork.Reservations.Add(reservation);
								}

								unitOfWork.Complete();
							}
						}
					
						List<Reservation> unitReservations = unitOfWork.Reservations.Find(r => r.AccommodationUnit.Id == unit.Id).ToList();
						
						//set reservation delete in localDB
						foreach (Reservation reservation in unitReservations)
						{
							int flag = 0;
							foreach (Reservation r in getUnitReservationsResponseDTO.Reservations)
							{
								if (r.Id == reservation.Id)
									flag += 1;
							}
							if (flag == 0)
							{
								Reservation rDB = unitOfWork.Reservations.Get(reservation.Id);
								rDB.Deleted = true;
								unitOfWork.Complete();
							}
						}
					}
					catch { }
				}
				return unitOfWork.Reservations.Find(r => r.AccommodationUnit.Accommodation.Id == accommodationId && r.Deleted == false).ToList();
			}
			else
				return unitOfWork.Reservations.Find(r => r.AccommodationUnit.Id == accommodationUnitId && r.Deleted == false).ToList();
		}

		public bool AddReservation(Reservation reservation)
		{
			AddReservationRequestDTO addReservationRequestDTO = new AddReservationRequestDTO(reservation);
			return reservationPortClient.addReservation(addReservationRequestDTO.AddReservationRequest).success;
		}

		public bool UpdateReservation(Reservation reservation)
		{
			UpdateReservationRequestDTO updateReservationRequestDTO = new UpdateReservationRequestDTO(reservation);
			return reservationPortClient.updateReservation(updateReservationRequestDTO.UpdateReservationRequest).success;
		}

		public bool DeleteReservation(long reservationId)
		{
			deleteReservationRequest deleteReservationRequest = new deleteReservationRequest() { reservation_id = reservationId };
			return reservationPortClient.deleteReservation(deleteReservationRequest).success;
		}

		public double setPrice(Reservation reservation)
		{

			double price = 0;
			try
			{
				List<PeriodPrice> periodPrices = new List<PeriodPrice>();

				periodPrices = unitOfWork.PeriodPrices.Find(p => p.AccommodationUnit.Id == reservation.AccommodationUnit.Id).ToList();
				if (periodPrices.Count > 0)
				{
					foreach (PeriodPrice p in periodPrices)
					{
						if (reservation.FromDate > p.FromDate && reservation.FromDate < p.ToDate)
						{
							price = 0;
							for (DateTime date = reservation.FromDate; date < reservation.ToDate; date = date.AddDays(1))
								price += p.Price;
							break;
						}
					}
				}
				if (price == 0)
				{
					for (var date = reservation.FromDate.Date; date < reservation.ToDate.Date; date = date.AddDays(1))
					{
						price += reservation.AccommodationUnit.DefaultPrice;
					}
				}
			}
			catch { }
			return price;
		}

		public Reservation GetReservation(long reservationId)
		{
			return unitOfWork.Reservations.Get(reservationId);
		}
	}
}
