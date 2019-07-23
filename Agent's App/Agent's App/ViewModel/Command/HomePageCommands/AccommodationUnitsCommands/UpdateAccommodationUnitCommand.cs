using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationUnitsCommands
{
	public class UpdateAccommodationUnitCommand : ICommand
	{
		public AccommodationUnit AccommodationUnit { get; set; }
		public HomePageViewModel HomePageViewModel { get; set; }

		public UpdateAccommodationUnitCommand(AccommodationUnit accommodationUnit, HomePageViewModel homePageViewModel)
		{
			AccommodationUnit = accommodationUnit;
			HomePageViewModel = homePageViewModel;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			HomePageViewModel.setUnitPage(AccommodationUnit);
		}
	}
}
