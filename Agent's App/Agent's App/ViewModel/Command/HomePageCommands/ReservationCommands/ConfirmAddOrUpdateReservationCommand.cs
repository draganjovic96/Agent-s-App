using Agent_s_App.Core.Model;
using Agent_s_App.ViewModel.HomePageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
			Reservation reservation = ReservationViewModel.Reservation;
			reservation.Guest = ReservationViewModel.Guest;
			reservation.FromDate = ReservationViewModel.FromDate;
			reservation.ToDate = ReservationViewModel.ToDate;
			reservation.AccommodationUnit = ReservationViewModel.Unit;
			reservation.Price = ReservationViewModel.Price;
			if (ReservationViewModel.AddOrSaveButton.Equals("Add"))
			{
				if (ReservationsViewModel.ReservationService.AddReservation(reservation))
					MessageBox.Show("Reservation added.");
				else
					MessageBox.Show("Can't add reservation");
			}
			else
			{
				reservation.AgentConfirmed = ReservationViewModel.AgentConfirmed;
				if (ReservationsViewModel.ReservationService.UpdateReservation(reservation))
					MessageBox.Show("Reservation updated.");
				else
					MessageBox.Show("Can't update reservation.");
			}
			HomePageViewModel.setReservationsPage(Unit);
		}
	}
}
