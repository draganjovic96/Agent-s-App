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
		private readonly AccommodationUnitService accommodationUnitService = new AccommodationUnitService();

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

	}
}
