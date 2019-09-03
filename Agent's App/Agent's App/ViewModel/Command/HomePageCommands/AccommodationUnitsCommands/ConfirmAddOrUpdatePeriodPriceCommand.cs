using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using Agent_s_App.View.HomePageViews;
using Agent_s_App.ViewModel.HomePageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationUnitsCommands
{
	public class ConfirmAddOrUpdatePeriodPriceCommand : ICommand
	{
		public PeriodPricesViewModel PeriodPricesViewModel { get; set; }
		public PeriodPriceViewModel PeriodPriceViewModel { get; set; }
		public HomePageViewModel HomePageViewModel { get; set; }
		public PeriodPrice PeriodPrice { get; set; }
		public PeriodPriceService periodPriceService = new PeriodPriceService();

		public ConfirmAddOrUpdatePeriodPriceCommand(PeriodPrice periodPrice,PeriodPriceViewModel periodPriceViewModel, PeriodPricesViewModel periodPricesViewModel, HomePageViewModel homePageViewModel)
		{
			PeriodPricesViewModel = periodPricesViewModel;
			PeriodPriceViewModel = periodPriceViewModel;
			HomePageViewModel = homePageViewModel;
			PeriodPrice = periodPrice;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			PeriodPrice.FromDate = PeriodPriceViewModel.FromDate;
			PeriodPrice.ToDate = PeriodPriceViewModel.ToDate;
			PeriodPrice.Price = double.Parse(PeriodPriceViewModel.Price);
			if (PeriodPriceViewModel.AddOrSaveButton.Equals("Add"))
				periodPriceService.AddPeriodPrice(PeriodPrice, PeriodPricesViewModel.AccommodationUnit.Id);
			else
			{
				PeriodPrice.AccommodationUnit.Id = PeriodPriceViewModel.PeriodPricesViewModel.AccommodationUnit.Id; 
				if(periodPriceService.UpdatePeriodPrice(PeriodPrice)) MessageBox.Show("Period price, with " + PeriodPrice.Id + " ID, updated.");
				else MessageBox.Show("Can't update period price.");
			}
			HomePageViewModel.ActivePage = new PeriodPricesView(HomePageViewModel, PeriodPricesViewModel.AccommodationUnit);
		}
	}
}
