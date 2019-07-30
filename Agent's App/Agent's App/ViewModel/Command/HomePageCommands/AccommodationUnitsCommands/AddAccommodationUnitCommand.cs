using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationUnitsCommands
{
	public class AddAccommodationUnitCommand : ICommand
	{
		public HomePageViewModel HomePageViewModel { get; set; }
		private AccommodationUnitService unitService = new AccommodationUnitService();

		public AddAccommodationUnitCommand(HomePageViewModel homePageViewModel)
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
			HomePageViewModel.setUnitPage(null);
		}
	}
}
