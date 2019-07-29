using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using Agent_s_App.View.MessagesPageViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Agent_s_App.ViewModel
{
	public class MessagesViewModel : ViewModelBase
	{
		private Reservation reservation;
		private UserControl conversationPage;

		public AgentViewModel AgentViewModel { get; set; }
		public List<Reservation> Reservations { get; set; }
		public ReservationService ReservationService = new ReservationService();
		
		public MessagesViewModel(AgentViewModel agentViewModel)
		{
			AgentViewModel = agentViewModel;
			Reservations = new List<Reservation>();
			foreach (Reservation reservation in ReservationService.GetReservations(0, AgentViewModel.Accommodation.Id))
			{
				if(reservation.Guest.Id != AgentViewModel.LoggedUser.Id)
					Reservations.Add(reservation);
			}
		}

		public Reservation Reservation
		{
			get => reservation;
			set
			{
				reservation = value;
				OnPropertyChanged("Reservation");
				setConversationPage();
			}
		}

		public UserControl ConversationPage
		{
			get => conversationPage;
			set
			{
				conversationPage = value;
				OnPropertyChanged("ConversationPage");
			}
		}

		public void setConversationPage()
		{
			ConversationPage = new ConversationView(Reservation, this);
		}
	}
}
