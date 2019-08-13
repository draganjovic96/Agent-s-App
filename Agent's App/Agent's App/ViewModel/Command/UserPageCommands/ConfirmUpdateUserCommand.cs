using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.UserPageCommands
{
	public class ConfirmUpdateUserCommand : ICommand
	{
		public UserService UserService = new UserService();
		public UserViewModel UserViewModel { get; set; }

		public ConfirmUpdateUserCommand(UserViewModel userViewModel)
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
			User user = new User();
			user = UserViewModel.User;
			user.Password = UserViewModel.Password;
			user.Name = UserViewModel.Name;
			user.LastName = UserViewModel.Lastname;
			UserService.UpdateUser(user);
			UserViewModel.AgentViewModel.LoggedUser = UserService.LogIn(user.Username, user.Password);
			UserViewModel.AgentViewModel.setUserPage();
		}
	}
}
