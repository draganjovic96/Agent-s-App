using Agent_s_App.View.HomePageViews;
using Agent_s_App.ViewModel.HomePageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationUnitsCommands
{
	public class PeriodPriceCommand : ICommand
	{
		public AccommodationUnitViewModel AccommodationUnitViewModel { get; set; }
		HomePageViewModel HomePageViewModel { get; set; }

		public PeriodPriceCommand(AccommodationUnitViewModel accommodationUnitViewModel, HomePageViewModel homePageViewModel)
		{
			AccommodationUnitViewModel = accommodationUnitViewModel;
			HomePageViewModel = homePageViewModel;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			HomePageViewModel.ActivePage = new PeriodPricesView(HomePageViewModel, AccommodationUnitViewModel.Unit);
		}
	}
}
