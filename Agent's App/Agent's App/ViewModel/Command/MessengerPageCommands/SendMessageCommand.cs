using Agent_s_App.Core.Model;
using Agent_s_App.Service;
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

		private MessageService messageService = new MessageService();

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
			Message message = new Message
			{
				MessageContent = ConversationViewModel.MessageContent,
				Sender = ConversationViewModel.MessagesViewModel.AgentViewModel.LoggedUser
			};

			messageService.SendMessage(ConversationViewModel.Reservation.Id, message);
			ConversationViewModel.MessagesViewModel.setConversationPage();
		}
	}
}
