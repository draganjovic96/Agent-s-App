using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using Agent_s_App.View.MessagesPageViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Agent_s_App.ViewModel
{
	public class ReservationWithSeen : INotifyPropertyChanged
	{
		public ReservationWithSeen(Reservation reservation, AgentViewModel agentViewModel)
		{
			Reservation = reservation;
			Seen = "Hidden";
			foreach (Message m in reservation.Messages)
			{
				if (m.Seen == false && m.Sender.Id != agentViewModel.LoggedUser.Id)
					Seen = "Visible";
			}
		}

		public ReservationWithSeen()
		{

		}

		private string seen;

		public Reservation Reservation { get; set; }

		public string Seen
		{
			get => seen;
			set
			{
				seen = value;
				OnPropertyChanged("Seen");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}

	public class MessagesViewModel : ViewModelBase
	{
		private ReservationWithSeen reservation;
		private UserControl conversationPage;
		private List<ReservationWithSeen> reservations;

		public AgentViewModel AgentViewModel { get; set; }
		public ReservationService ReservationService = new ReservationService();
		
		public MessagesViewModel(AgentViewModel agentViewModel)
		{
			AgentViewModel = agentViewModel;
			setConversationsList();
		}

		public ReservationWithSeen Reservation
		{
			get => reservation;
			set
			{
				reservation = value;
				OnPropertyChanged("Reservation");
				setConversationPage();
				if (reservation != null)
				{ 
					if (reservation.Seen.Equals("Visible"))
					{
						foreach (Message m in reservation.Reservation.Messages)
						{
							if (m.Seen == false)
							{
								m.Seen = true;
								reservation.Seen = "Hidden";
							}
						}
					}
					ReservationService.AddReservation(reservation.Reservation);
				}
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

		public List<ReservationWithSeen> Reservations
		{
			get => reservations;
			set
			{
				reservations = value;
				OnPropertyChanged("Reservations");
			}
		}

		public void setConversationPage()
		{
			ConversationPage = new ConversationView(Reservation.Reservation, this);
		}

		public void setConversationsList()
		{
			Reservations = new List<ReservationWithSeen>();
			foreach (Reservation reservation in ReservationService.GetReservations(0, AgentViewModel.Accommodation.Id))
			{
				if (reservation.Guest.Id != AgentViewModel.LoggedUser.Id && reservation.Messages.Count > 0)
				{
					List<Message> messages = reservation.Messages.ToList();
					messages.OrderByDescending(x => x.DatumVreme);
					reservation.Messages = messages;

					Reservations.Add(new ReservationWithSeen(reservation, AgentViewModel));
				}
			}
			Reservations.OrderByDescending(x => x.Reservation.Messages.First().DatumVreme);
		}
	}
}
