using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			throw new NotImplementedException();
		}

		public void Execute(object parameter)
		{
			throw new NotImplementedException();
		}
	}
}
