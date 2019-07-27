using Agent_s_App.Core.Model;
using Agent_s_App.View.HomePageViews;
using Agent_s_App.ViewModel.HomePageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.HomePageCommands.ReservationCommands
{
	public class AddReservationCommand : ICommand
	{
		public AccommodationUnit AccommodationUnit { get; set; }
		public ReservationsViewModel ReservationsViewModel { get; set; }
		public Reservation Reservation { get; set; }
		public AddReservationCommand(AccommodationUnit accommodationUnit, Reservation reservation, ReservationsViewModel reservationsViewModel)
		{
			AccommodationUnit = accommodationUnit;
			ReservationsViewModel = reservationsViewModel;
			Reservation = reservation;
		}
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			ReservationsViewModel.HomePageViewModel.ActivePage = new ReservationView(Reservation, ReservationsViewModel); ;
		}
	}
}
