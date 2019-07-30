using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.MessengerPageCommands
{
	public class SendMessageCommand : ICommand
	{
		public ConversationViewModel ConversationViewModel { get; set; }

		public SendMessageCommand(ConversationViewModel conversationViewModel)
		{
			ConversationViewModel = conversationViewModel;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			Random rnd = new Random();
			Message message = new Message();
			message.Id = rnd.Next(1846240);
			message.MessageContent = ConversationViewModel.MessageContent;
			message.Sender = ConversationViewModel.MessagesViewModel.AgentViewModel.LoggedUser;
			message.Receiver = ConversationViewModel.Reservation.Guest;
			message.DatumVreme = DateTime.Now;
			ConversationViewModel.Reservation.Messages.Add(message);
			ConversationViewModel.MessagesViewModel.setConversationPage();
		}
	}
}
