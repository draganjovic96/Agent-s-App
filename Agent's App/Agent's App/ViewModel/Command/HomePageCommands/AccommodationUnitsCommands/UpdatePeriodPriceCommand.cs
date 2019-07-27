using Agent_s_App.Core.Model;
using Agent_s_App.Service;
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
	public class UpdatePeriodPriceCommand : ICommand
	{
		public HomePageViewModel HomePageViewModel { get; set; }
		public PeriodPricesViewModel PeriodPricesViewModel { get; set; }
		public PeriodPrice PeriodPrice { get; set; }
		public PeriodPriceService periodPriceService = new PeriodPriceService();

		public UpdatePeriodPriceCommand(PeriodPrice periodPrice, PeriodPricesViewModel periodPricesViewModel, HomePageViewModel homePageViewModel)
		{
			PeriodPrice = periodPrice;
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
			PeriodPricesViewModel.PeriodPricePage = new PeriodPriceView(PeriodPrice, PeriodPricesViewModel, HomePageViewModel);
		}
	}
}
