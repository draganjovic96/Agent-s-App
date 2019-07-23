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
	public class DeleteAccommodationUnitCommand : ICommand
	{
		public AccommodationUnitService unitService = new AccommodationUnitService();
		public HomePageViewModel HomePageViewModel { get; set; }
		public AccommodationUnit AccommodationUnit { get; set; }
		public DeleteAccommodationUnitCommand(AccommodationUnit accommodationUnit, HomePageViewModel homePageViewModel)
		{
			AccommodationUnit = accommodationUnit;
			HomePageViewModel = homePageViewModel;
		}
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			unitService.DeleteAccommodationUnit(AccommodationUnit);
			HomePageViewModel.setUnitsPage();
		}
	}
}
