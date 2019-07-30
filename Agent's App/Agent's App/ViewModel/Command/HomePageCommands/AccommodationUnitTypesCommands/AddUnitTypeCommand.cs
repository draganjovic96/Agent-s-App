using Agent_s_App.View.HomePageViews;
using Agent_s_App.ViewModel.HomePageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationUnitTypesCommands
{
	public class AddUnitTypeCommand : ICommand
	{
		public AccommodationUnitTypesViewModel AccommodationUnitTypesViewModel { get; set; }
		public HomePageViewModel HomePageViewModel { get; set; }

		public AddUnitTypeCommand(AccommodationUnitTypesViewModel accommodationUnitTypesViewModel, HomePageViewModel homePageViewModel)
		{
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
			AccommodationUnitTypesViewModel.UnitTypePage = new UnitTypeView(null, AccommodationUnitTypesViewModel ,HomePageViewModel);
		}
	}
}
