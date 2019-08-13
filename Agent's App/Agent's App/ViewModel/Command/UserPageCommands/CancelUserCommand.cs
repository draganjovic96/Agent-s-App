using Agent_s_App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.UserPageCommands
{
	public class CancelUserCommand : ICommand
	{
		public UserViewModel UserViewModel { get; set; }

		private UserService userService = new UserService();

		public CancelUserCommand(UserViewModel userViewModel)
		{
			UserViewModel = userViewModel;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			UserViewModel.AgentViewModel.LoggedUser = userService.LogIn(UserViewModel.AgentViewModel.LoggedUser.Username, UserViewModel.AgentViewModel.LoggedUser.Password);
			UserViewModel.AgentViewModel.setUserPage();
		}
	}
}
