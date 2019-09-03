using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using Agent_s_App.ViewModel.Command.HomePageCommands;
using Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationUnitsCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ViewModel.HomePageViewModels
{
	public class AccommodationUnitViewModel : ViewModelBase
	{
		#region fields

		private AccommodationUnitService unitService = new AccommodationUnitService();
		private AccommodationUnitTypeService unitTypeService = new AccommodationUnitTypeService();
		private string floor;
		private string number;
		private string numberOfBeds;
		private string defaultPrice;
		private List<AccommodationUnitType> unitTypes;
		private AccommodationUnitType unitType;
		private bool enableButton;

		#endregion
		public PeriodPriceCommand PeriodPriceCommand { get; set; }
		public ConfirmAddOrUpdateUnitCommand ConfirmAddOrUpdateUnit { get; set; }
		public HomePageViewModel HomePageViewModel { get; set; }
		public AccommodationUnit Unit { get; set; }
		public CancelAccommodationUnitCommand CancelAccommodationUnitCommand { get; set; }
		public ReservationsPageCommand ReservationsPageCommand { get; set; }

		public AccommodationUnitViewModel(AccommodationUnit unit, HomePageViewModel homePageViewModel)
		{
			HomePageViewModel = homePageViewModel;
			UnitTypes = unitTypeService.GetAccommodationUnitTypes();
			if (unit != null)
			{
				AddOrUpdateButton = "Save";
				Unit = unit;
				Floor = unit.Floor.ToString();
				NumberOfBeds = unit.NumberOfBeds.ToString();
				Number = unit.Number;
				DefaultPrice = unit.DefaultPrice.ToString();
				EnableButton = false;
				PeriodPriceCommand = new PeriodPriceCommand(this, HomePageViewModel);
				ReservationsPageCommand = new ReservationsPageCommand(Unit, HomePageViewModel);
				UnitType = unit.AccommodationUnitType;
			}
			else
			{
				AddOrUpdateButton = "Add";
				Unit = new AccommodationUnit();
			}
			ConfirmAddOrUpdateUnit = new ConfirmAddOrUpdateUnitCommand(Unit, this, HomePageViewModel);
			CancelAccommodationUnitCommand = new CancelAccommodationUnitCommand(HomePageViewModel);
		}

		public string AddOrUpdateButton { get; set; }

		public string Floor {
			get => floor;
			set
			{
				floor = value;
				OnPropertyChanged("Floor");
				EnableButton = true;
			}
		}

		public string Number
		{
			get => number;
			set
			{
				number = value;
				OnPropertyChanged("Number");
				EnableButton = true;
			}
		}

		public string NumberOfBeds
		{
			get => numberOfBeds;
			set
			{
				numberOfBeds = value;
				OnPropertyChanged("NumberOfBeds");
				EnableButton = true;
			}
		}

		public string DefaultPrice
		{
			get => defaultPrice;
			set
			{
				defaultPrice = value;
				OnPropertyChanged("DefaultPrice");
				EnableButton = true;
			}
		}

		public List<AccommodationUnitType> UnitTypes
		{
			get => unitTypes;
			set => unitTypes = value;
		}

		public AccommodationUnitType UnitType
		{
			get => unitType;
			set
			{
				unitType = value;
				EnableButton = true;
				OnPropertyChanged("UnitType");
			}
		}

		public bool EnableButton
		{
			get => enableButton;
			set
			{
				enableButton = value;
				OnPropertyChanged("EnableButton");
			}
		}
	}
}
