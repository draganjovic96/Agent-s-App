using Agent_s_App.Core.Model;
using Agent_s_App.ViewModel.Command.MessengerPageCommands;
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
			if (message.MessageContent.Length < 70)
			Width = message.MessageContent.Length * 10;
			else
				Width = 700;
			if (Message.Sender.Id == messagesViewModel.AgentViewModel.LoggedUser.Id)
			{
				Alignment = "Left";
				Position = 0;
				Color = "Blue";
			}
			else
			{
				Alignment = "Right";
				Position = 1;
				Color = "Gray";
			}

		}

		public Message Message { get; set; }
		public int Position { get; set; }
		public int Width { get; set; }
		public string Alignment { get; set; }
		public string Color { get; set; }
	}

	public class ConversationViewModel : ViewModelBase
	{
		private string messageContent;

		public MessagesViewModel MessagesViewModel { get; set; }
		public List<MessageWithAlignment> Messages { get; set; }
		public Reservation Reservation { get; set; }
		public SendMessageCommand SendMessageCommand { get; set; }
		public ConversationViewModel(Reservation reservation, MessagesViewModel messagesViewModel)
		{
			Reservation = reservation;
			MessagesViewModel = messagesViewModel;
			Messages = new List<MessageWithAlignment>();
			foreach (Message m in Reservation.Messages.OrderBy(x => x.DatumVreme))
			{
				Messages.Add(new MessageWithAlignment(m, MessagesViewModel));
			}
			SendMessageCommand = new SendMessageCommand(this);
		}

		public string MessageContent
		{
			get => messageContent;
			set
			{
				messageContent = value;
				OnPropertyChanged("MessageContent");
			}
		}

	}
}
