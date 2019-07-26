using Agent_s_App.Core.Model;
using Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationUnitsCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ViewModel.HomePageViewModels
{
    public class PeriodPriceViewModel : ViewModelBase
    {
		private DateTime fromDate;
		private DateTime toDate;
		private string price;
		private string addOrSaveButton;

		public PeriodPrice PeriodPrice { get; set; }
		public PeriodPricesViewModel PeriodPricesViewModel { get; set; }
		public HomePageViewModel HomePageViewModel { get; set; }
		public ConfirmAddOrUpdatePeriodPriceCommand AddOrUpdatePeriodPriceCommand { get; set; }
		public CancelPeriodPriceCommand CancelPeriodPriceCommand { get; set; }

		public PeriodPriceViewModel(PeriodPrice periodPrice, PeriodPricesViewModel periodPricesViewModel, HomePageViewModel homePageViewModel)
		{
			PeriodPricesViewModel = periodPricesViewModel;
			HomePageViewModel = homePageViewModel;
			if (periodPrice != null)
			{
				PeriodPrice = periodPrice;
				FromDate = periodPrice.FromDate;
				ToDate = periodPrice.ToDate;
				Price = periodPrice.Price.ToString();
				AddOrSaveButton = "Save";
			}
			else
			{
				FromDate = new DateTime(2001, 1, 1);
				ToDate = new DateTime(2001, 1, 1);
				PeriodPrice = new PeriodPrice();
				AddOrSaveButton = "Add";
			}
			AddOrUpdatePeriodPriceCommand = new ConfirmAddOrUpdatePeriodPriceCommand(PeriodPrice, this, PeriodPricesViewModel, HomePageViewModel);
			CancelPeriodPriceCommand = new CancelPeriodPriceCommand(PeriodPricesViewModel, HomePageViewModel);


		}

		public DateTime FromDate
		{
			get => fromDate;
			set
			{
				fromDate = value;
				OnPropertyChanged("FromDate");
			}
		}

		public DateTime ToDate
		{
			get => toDate;
			set
			{
				toDate = value;
				OnPropertyChanged("ToDate");
			}
		}

		public string Price
		{
			get => price;
			set
			{
				price = value;
				OnPropertyChanged("Price");
			}
		}

		public string AddOrSaveButton
		{
			get => addOrSaveButton;
			set
			{
				addOrSaveButton = value;
				OnPropertyChanged("AddOrSaveButton");
			}
		}
	}
}
