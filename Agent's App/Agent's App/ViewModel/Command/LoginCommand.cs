using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command
{
	public class LoginCommand : ICommand
	{
		public LoginViewModel LoginViewModel { get; set; }
		public MainViewModel MainViewModel { get; set; }

		public LoginCommand(LoginViewModel loginViewModel, MainViewModel mainViewModel)
		{
			this.LoginViewModel = loginViewModel;
			this.MainViewModel = mainViewModel;
		}
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			var passwordBox = parameter as PasswordBox;
			string password = passwordBox.Password;
			MainViewModel.SetActivePage(LoginViewModel.LoginUser(password));
		}
	}
}
