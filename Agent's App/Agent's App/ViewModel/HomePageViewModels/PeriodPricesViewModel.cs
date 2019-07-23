using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using Agent_s_App.View.HomePageViews;
using Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationUnitsCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Agent_s_App.ViewModel.HomePageViewModels
{
    public class PeriodPricesViewModel : ViewModelBase
    {
		private List<PeriodPrice> periodPrices;
		private PeriodPrice periodPrice;
		private bool enableUpdate;
		private UserControl periodPricePage;
		private PeriodPriceService periodPriceService = new PeriodPriceService();

		public HomePageViewModel HomePageViewModel { get; set; }
		public AccommodationUnit AccommodationUnit { get; set; }
		public AddPeriodPriceCommand AddPeriodPriceCommand { get; set; }
		public PeriodPricesViewModel(HomePageViewModel homePageViewModel, AccommodationUnit accommodationUnit)
		{
			HomePageViewModel = homePageViewModel;
			AccommodationUnit = accommodationUnit;
			PeriodPrices = periodPriceService.GetPeriodPrices(AccommodationUnit.Id);
			AddPeriodPriceCommand = new AddPeriodPriceCommand(this);
			PeriodPricePage = null;
		}

		public List<PeriodPrice> PeriodPrices
		{
			get => periodPrices;
			set
			{
				periodPrices = value;
				OnPropertyChanged("PeriodPrices");
			}
		}

		public PeriodPrice PeriodPrice
		{
			get => periodPrice;
			set
			{
				periodPrice = value;
				if (periodPrice != null) EnableUpdate = true;
				else EnableUpdate = false;
				OnPropertyChanged("PeriodPrice");
			}
		}

		public bool EnableUpdate
		{
			get => enableUpdate;
			set
			{
				enableUpdate = value;
				OnPropertyChanged("EnableUpdate");
			}
		}

		public UserControl PeriodPricePage
		{
			get => periodPricePage;
			set
			{
				periodPricePage = value;
				OnPropertyChanged("PeriodPricePage");
			}
		}

		public void setPeriodPricePage(PeriodPrice periodPrice)
		{
			PeriodPricePage = new PeriodPriceView(periodPrice);
		}
	}
}
