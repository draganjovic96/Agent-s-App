using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using Agent_s_App.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agent_s_App.ViewModel
{
	public class LoginViewModel : ViewModelBase
	{
		private UserService userService = new UserService();
		private string username;
		private string visible;

		public LoginCommand LoginCommand { get; set; }

		public LoginViewModel(string visible, MainViewModel mainViewModel)
		{
			Visible = visible;
			LoginCommand = new LoginCommand(this, mainViewModel);
		}

		public User LoginUser(string password)
		{
			return userService.LogIn(Username, password);
		}

		public string Username
		{
			get => username; 
			set {
				username = value;
				if(username != "") Visible = "Hidden";
			}
		}

		public string Visible
		{
			get => visible;
			set
			{
				visible = value;
				OnPropertyChanged("Visible");
			}
		}

	}
}
