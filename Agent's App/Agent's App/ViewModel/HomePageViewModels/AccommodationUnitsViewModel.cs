using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationUnitsCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ViewModel.HomePageViewModels
{
	public class AccommodationUnitsViewModel : ViewModelBase
	{
		private List<AccommodationUnit> units;
		private AccommodationUnit selectedUnit;
		private readonly AccommodationUnitService accommodationUnitService = new AccommodationUnitService();
		private bool enableUpdate;
		private UpdateAccommodationUnitCommand updateAccommodationUnitCommand;
		private DeleteAccommodationUnitCommand deleteAccommodationUnitCommand;

		public HomePageViewModel HomePageViewModel { get; set; }
		public AddAccommodationUnitCommand AddAccommodationUnitCommand { get; set; }

		public AccommodationUnitsViewModel(long accommodationId, HomePageViewModel homePageViewModel)
		{
			Units = accommodationUnitService.GetAccommodationUnits(accommodationId);
			HomePageViewModel = homePageViewModel;
			AddAccommodationUnitCommand = new AddAccommodationUnitCommand(homePageViewModel);
		}


		public List<AccommodationUnit> Units
		{
			get => units;
			set
			{
				units = value;
				OnPropertyChanged("Units");
			}
		}

		public AccommodationUnit SelectedUnit
		{
			get => selectedUnit;
			set
			{
				selectedUnit = value;
				if (selectedUnit != null) EnableUpdate = true;
				else EnableUpdate = false;
				UpdateAccommodationUnitCommand = new UpdateAccommodationUnitCommand(SelectedUnit, HomePageViewModel);
				DeleteAccommodationUnitCommand = new DeleteAccommodationUnitCommand(SelectedUnit, HomePageViewModel);
				OnPropertyChanged("SelectedUnit");
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

		public UpdateAccommodationUnitCommand UpdateAccommodationUnitCommand
		{
			get => updateAccommodationUnitCommand;
			set
			{
				updateAccommodationUnitCommand = value;
				OnPropertyChanged("UpdateAccommodationUnitCommand");
			}
		}

		public DeleteAccommodationUnitCommand DeleteAccommodationUnitCommand
		{
			get => deleteAccommodationUnitCommand;
			set
			{
				deleteAccommodationUnitCommand = value;
				OnPropertyChanged("DeleteAccommodationUnitCommand");
			}
		}
	}
}
