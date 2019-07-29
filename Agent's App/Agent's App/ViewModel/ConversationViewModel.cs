using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ViewModel
{
	public class MessageWithAlignment
	{
		public MessageWithAlignment(Message message, MessagesViewModel messagesViewModel)
		{
			Message = message;
			if (Message.Sender.Id == messagesViewModel.AgentViewModel.LoggedUser.Id)
			{
				Alignment = 0;
				Color = "Blue";
			}
			else
			{
				Alignment = 1;
				Color = "Gray";
			}

		}

		public Message Message { get; set; }
		public int Alignment { get; set; }
		public string Color { get; set; }
	}
	public class ConversationViewModel : ViewModelBase
	{
		public MessagesViewModel MessagesViewModel { get; set; }
		public List<MessageWithAlignment> Messages { get; set; }
		public Reservation Reservation { get; set; }

		public ConversationViewModel(Reservation reservation, MessagesViewModel messagesViewModel)
		{
			Reservation = reservation;
			MessagesViewModel = messagesViewModel;
			Messages = new List<MessageWithAlignment>();
			foreach (Message m in Reservation.Messages)
			{
				Messages.Add(new MessageWithAlignment(m, MessagesViewModel));
			}
		}
	}
}
