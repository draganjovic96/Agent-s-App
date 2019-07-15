using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using Agent_s_App.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ViewModel
{
	public class LoginViewModel : ViewModelBase
	{
		private UserService userService = new UserService();

		public string Visible { get; set; }
		public LoginCommand LoginCommand { get; set; }
		public string Username { get; set; }

		public LoginViewModel(string visible, MainViewModel mainViewModel)
		{
			Console.WriteLine(visible);
			Visible = visible;
			LoginCommand = new LoginCommand(this, mainViewModel);
		}

		public User LoginUser(string password)
		{
			return userService.LogIn(Username, password);
		}
	}
}
