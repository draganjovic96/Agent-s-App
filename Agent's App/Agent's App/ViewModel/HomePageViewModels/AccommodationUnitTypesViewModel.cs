using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationUnitTypesCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Agent_s_App.ViewModel.HomePageViewModels
{
	public class AccommodationUnitTypesViewModel : ViewModelBase
	{
		private AccommodationUnitTypeService accommodationUnitService = new AccommodationUnitTypeService();
		private List<AccommodationUnitType> unitTypes;
		private AccommodationUnitType unitType;
		private UserControl unitTypePage;
		private bool enableUpdate;
		private UpdateAccommodationUnitTypeCommand updateAccommodationUnitTypeCommand;
		private DeleteAccommodationUnitTypeCommand deleteAccommodationUnitTypeCommand;

		public Accommodation Accommodation { get; set; }
		public HomePageViewModel HomePageViewModel { get; set; }
		public AddUnitTypeCommand AddUnitTypeCommand { get; set; }

		public AccommodationUnitTypesViewModel(Accommodation accommodation, HomePageViewModel homePageViewModel)
		{
			Accommodation = accommodation;
			HomePageViewModel = homePageViewModel;
			UnitTypes = accommodationUnitService.GetAccommodationUnitTypes(Accommodation.Id);
			AddUnitTypeCommand = new AddUnitTypeCommand(this, HomePageViewModel);
			EnableUpdate = false;
		}

		public List<AccommodationUnitType> UnitTypes
		{
			get => unitTypes;
			set
			{
				unitTypes = value;
				OnPropertyChanged("UnitTypes");
			}
		}

		public AccommodationUnitType UnitType
		{
			get => unitType;
			set
			{
				unitType = value;
				EnableUpdate = true;
				UnitTypePage = null;
				UpdateAccommodationUnitTypeCommand = new UpdateAccommodationUnitTypeCommand(UnitType, this, HomePageViewModel);
				DeleteAccommodationUnitTypeCommand = new DeleteAccommodationUnitTypeCommand(this, HomePageViewModel);
				OnPropertyChanged("UnitType");
			}
		}

		public UserControl UnitTypePage
		{
			get => unitTypePage;
			set
			{
				unitTypePage = value;
				OnPropertyChanged("UnitTypePage");
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

		public UpdateAccommodationUnitTypeCommand UpdateAccommodationUnitTypeCommand
		{
			get => updateAccommodationUnitTypeCommand;
			set
			{
				updateAccommodationUnitTypeCommand = value;
				OnPropertyChanged("UpdateAccommodationUnitTypeCommand");
			}
		}

		public DeleteAccommodationUnitTypeCommand DeleteAccommodationUnitTypeCommand
		{
			get => deleteAccommodationUnitTypeCommand;
			set
			{
				deleteAccommodationUnitTypeCommand = value;
				OnPropertyChanged("DeleteAccommodationUnitTypeCommand");
			}
		}
	}
}
