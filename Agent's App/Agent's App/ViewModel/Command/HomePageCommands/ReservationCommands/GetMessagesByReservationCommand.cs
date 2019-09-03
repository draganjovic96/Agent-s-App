using Agent_s_App.Service;
using Agent_s_App.View;
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
	public class GetMessagesByReservationCommand : ICommand
	{
		public ReservationViewModel ReservationViewModel { get; set; }
		public long ReservationId { get; set; }
		public ReservationService ReservationService = new ReservationService();

		public GetMessagesByReservationCommand(long reservationId, ReservationViewModel reservationViewModel)
		{
			ReservationViewModel = reservationViewModel;
			ReservationId = reservationId;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			AgentViewModel agentViewModel = ReservationViewModel.ReservationsViewModel.HomePageViewModel.AgentViewModel;
			ReservationService.GetReservations(0, agentViewModel.Accommodation.Id);
			if (ReservationService.GetReservation(ReservationId).Messages.Count > 0)
			{
				agentViewModel.setMessagesPage();
				MessagesViewModel messagesViewModel = (MessagesViewModel)((MessagesView)agentViewModel.ActivePage).DataContext;
				messagesViewModel.Reservation = messagesViewModel.Reservations.Find(r => r.Reservation.Id == ReservationId);
			}
			else
			{
				MessageBox.Show("There are no messages for this reservation.");
			}
		}
	}
}
