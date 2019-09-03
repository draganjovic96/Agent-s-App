using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using Agent_s_App.ViewModel.HomePageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationUnitTypesCommands
{
	public class ConfirmAddOrUpdateUnitTypeCommand : ICommand
	{
		private AccommodationUnitTypeService accommodationUnitTypeService = new AccommodationUnitTypeService();

		public AccommodationUnitType AccommodationUnitType { get; set; }
		public AccommodationUnitTypeViewModel AccommodationUnitTypeViewModel { get; set; }
		public AccommodationUnitTypesViewModel AccommodationUnitTypesViewModel { get; set; }
		public HomePageViewModel HomePageViewModel { get; set; }

		public ConfirmAddOrUpdateUnitTypeCommand(AccommodationUnitType accommodationUnitType, AccommodationUnitTypeViewModel accommodationUnitTypeViewModel, AccommodationUnitTypesViewModel accommodationUnitTypesViewModel, HomePageViewModel homePageViewModel)
		{
			AccommodationUnitType = accommodationUnitType;
			AccommodationUnitTypeViewModel = accommodationUnitTypeViewModel;
			AccommodationUnitTypesViewModel = accommodationUnitTypesViewModel;
			HomePageViewModel = homePageViewModel;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			AccommodationUnitType.Name = AccommodationUnitTypeViewModel.Name;
			if (AccommodationUnitTypeViewModel.AddOrSaveButton.Equals("Add"))
				accommodationUnitTypeService.AddAccommodationUnitType(AccommodationUnitType);
			else
			{
				accommodationUnitTypeService.UpdateAccommodationUnitType(AccommodationUnitType);
			}
			HomePageViewModel.setUnitTypesPage();
		}
	}
}
