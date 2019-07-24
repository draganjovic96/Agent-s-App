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
	public class CancelPeriodPriceCommand : ICommand
	{
		public PeriodPricesViewModel PeriodPricesViewModel { get; set; }
		public HomePageViewModel HomePageViewModel { get; set; }

		public CancelPeriodPriceCommand(PeriodPricesViewModel periodPricesViewModel, HomePageViewModel homePageViewModel)
		{
			PeriodPricesViewModel = periodPricesViewModel;
			HomePageViewModel = homePageViewModel;
		}
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			HomePageViewModel.ActivePage = new PeriodPricesView(HomePageViewModel, PeriodPricesViewModel.AccommodationUnit);
		}
	}
}
