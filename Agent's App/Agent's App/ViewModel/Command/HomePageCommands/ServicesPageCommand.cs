using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.HomePageCommands
{
	public class ServicesPageCommand : ICommand
	{
		public HomePageViewModel HomePageViewModel;
		public ServicesPageCommand(HomePageViewModel homePageViewModel)
		{
			HomePageViewModel = homePageViewModel; 
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			HomePageViewModel.setServicesPage();
		}
	}
}
