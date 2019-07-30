using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.HomePageCommands
{
	public class UnitsPageCommand : ICommand
	{
		public HomePageViewModel HomePageViewModel { get; set; }

		public UnitsPageCommand(HomePageViewModel homePageViewModel)
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
			HomePageViewModel.setUnitsPage();
		}
	}
}
