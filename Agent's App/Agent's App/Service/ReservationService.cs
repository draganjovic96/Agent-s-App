using Agent_s_App.Core.Model;
using Agent_s_App.Persistance.Repository;
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

		public List<Reservation> GetReservations(long accommodationUnitId, long accommodationId)
		{
			if (accommodationUnitId == 0)
				return unitOfWork.Reservations.Find(r => r.AccommodationUnit.Accommodation.Id == accommodationId).ToList();
			else
				return unitOfWork.Reservations.Find(r => r.AccommodationUnit.Id == accommodationUnitId).ToList();
		}

		public void AddReservation(Reservation reservation)
		{
			unitOfWork.Reservations.Add(reservation);
			unitOfWork.Complete();
		}
	}
}
