using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationUnitsCommands
{
	public class ClosePeriodPricesCommand : ICommand
	{
		public HomePageViewModel HomePageViewModel { get; set; }
		public AccommodationUnit AccommodationUnit { get; set; }

		public ClosePeriodPricesCommand(HomePageViewModel homePageViewModel, AccommodationUnit accommodationUnit)
		{
			HomePageViewModel = homePageViewModel;
			AccommodationUnit = accommodationUnit;
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
