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
	public class UpdateReservationCommand : ICommand
	{
		public ReservationsViewModel ReservationsViewModel { get; set; }

		public UpdateReservationCommand(ReservationsViewModel reservationsViewModel)
		{
			ReservationsViewModel = reservationsViewModel;
		}
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			ReservationsViewModel.HomePageViewModel.ActivePage = new ReservationView(ReservationsViewModel.Reservation, ReservationsViewModel);
		}
	}
}
