using Agent_s_App.Core.Model;
using Agent_s_App.ViewModel.HomePageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.HomePageCommands.ReservationCommands
{
	public class ConfirmAddOrUpdateReservationCommand : ICommand
	{
		public HomePageViewModel HomePageViewModel { get; set; }
		public ReservationsViewModel ReservationsViewModel { get; set; }
		public ReservationViewModel ReservationViewModel { get; set; }
		public AccommodationUnit Unit { get; set; }

		public ConfirmAddOrUpdateReservationCommand(ReservationViewModel reservationViewModel)
		{

			HomePageViewModel = reservationViewModel.ReservationsViewModel.HomePageViewModel;
			ReservationsViewModel = reservationViewModel.ReservationsViewModel;
			ReservationViewModel = reservationViewModel;
			Unit = reservationViewModel.ReservationsViewModel.Unit;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			Random rnd = new Random();
			Reservation reservation = ReservationViewModel.Reservation;
			if (reservation.Id == 0) reservation.Id = rnd.Next(13456);
			reservation.Guest = ReservationViewModel.Guest;
			reservation.FromDate = ReservationViewModel.FromDate;
			reservation.ToDate = ReservationViewModel.ToDate;
			reservation.AgentConfirmed = ReservationViewModel.AgentConfirmed;
			reservation.AccommodationUnit = ReservationViewModel.Unit;
			ReservationsViewModel.ReservationService.AddReservation(reservation);
			HomePageViewModel.setReservationsPage(Unit);
		}
	}
}
