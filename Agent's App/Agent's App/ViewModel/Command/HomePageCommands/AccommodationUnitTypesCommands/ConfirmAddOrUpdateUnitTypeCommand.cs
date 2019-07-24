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
			Random rnd = new Random();
			if (AccommodationUnitType.Id == 0) AccommodationUnitType.Id = rnd.Next(100000);
			AccommodationUnitType.Name = AccommodationUnitTypeViewModel.Name;
			accommodationUnitTypeService.AddAccommodationUnitType(AccommodationUnitType);
			HomePageViewModel.setUnitTypesPage();
		}
	}
}
