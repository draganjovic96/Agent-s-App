using Agent_s_App.Core.Model;
using Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationUnitTypesCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ViewModel.HomePageViewModels
{
	public class AccommodationUnitTypeViewModel : ViewModelBase
	{
		private string addOrSaveButton;
		private string name;

		public AccommodationUnitType AccommodationUnitType { get; set; }
		public AccommodationUnitTypesViewModel AccommodationUnitTypesViewModel { get; set; }
		public HomePageViewModel HomePageViewModel { get; set; }
		public ConfirmAddOrUpdateUnitTypeCommand ConfirmAddOrUpdateUnitTypeCommand{ get; set; }
		public CancelAccommodationUnitTypeCommand CancelAccommodationUnitTypeCommand { get; set; }

		public AccommodationUnitTypeViewModel(AccommodationUnitType accommodationUnitType, AccommodationUnitTypesViewModel accommodationUnitTypesViewModel, HomePageViewModel homePageViewModel)
		{
			if (accommodationUnitType != null)
			{
				AccommodationUnitType = accommodationUnitType;
				AddOrSaveButton = "Save";
				Name = AccommodationUnitType.Name;
			}
			else
			{
				AccommodationUnitType = new AccommodationUnitType();
				AddOrSaveButton = "Add";
			}
			HomePageViewModel = homePageViewModel;
			AccommodationUnitTypesViewModel = accommodationUnitTypesViewModel;
			ConfirmAddOrUpdateUnitTypeCommand = new ConfirmAddOrUpdateUnitTypeCommand(AccommodationUnitType, this, AccommodationUnitTypesViewModel, HomePageViewModel);
			CancelAccommodationUnitTypeCommand = new CancelAccommodationUnitTypeCommand(HomePageViewModel);
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

		public string Name
		{
			get => name;
			set
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}
	}
}
