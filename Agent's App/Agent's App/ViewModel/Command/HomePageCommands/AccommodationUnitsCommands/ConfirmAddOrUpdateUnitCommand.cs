using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using Agent_s_App.ViewModel.HomePageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationUnitsCommands
{
	public class ConfirmAddOrUpdateUnitCommand : ICommand
	{
		private AccommodationUnitService unitService = new AccommodationUnitService();

		public HomePageViewModel HomePageViewModel { get; set; }
		public AccommodationUnit AccommodationUnit { get; set; }
		public AccommodationUnitViewModel AccommodationUnitViewModel { get; set; }

		public ConfirmAddOrUpdateUnitCommand(AccommodationUnit accommodationUnit, AccommodationUnitViewModel accommodationUnitViewModel, HomePageViewModel homePageViewModel)
		{
			AccommodationUnit = accommodationUnit;
			AccommodationUnitViewModel = accommodationUnitViewModel;
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
			if (AccommodationUnit.Id == 0) AccommodationUnit.Id = rnd.Next(234151);
			AccommodationUnit.Accommodation = HomePageViewModel.Accommodation;
			AccommodationUnit.Floor = Int32.Parse(AccommodationUnitViewModel.Floor);
			AccommodationUnit.Number = AccommodationUnitViewModel.Number;
			AccommodationUnit.NumberOfBeds = Int32.Parse(AccommodationUnitViewModel.NumberOfBeds);
			AccommodationUnit.DefaultPrice = Double.Parse(AccommodationUnitViewModel.DefaultPrice);
			AccommodationUnit.AccommodationUnitType = AccommodationUnitViewModel.UnitType;

			unitService.AddAccommodationUnit(AccommodationUnit);

			HomePageViewModel.setUnitsPage();
		}
	}
}
