using Agent_s_App.Service;
using Agent_s_App.View.HomePageViews;
using Agent_s_App.ViewModel.HomePageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationServicesCommand
{
	public class SaveServiceAffiliationCommand : ICommand
	{
		public AccommodationServicesViewModel AccommodationServicesViewModel { get; set; }
		public AccommodationServiceService AccommodationServiceService = new AccommodationServiceService();

		public SaveServiceAffiliationCommand(AccommodationServicesViewModel accommodationServicesViewModel)
		{
			AccommodationServicesViewModel = accommodationServicesViewModel;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			AccommodationServiceService.SaveAffiliation(AccommodationServicesViewModel.HomePageViewModel.Accommodation, ((ServiceWithAffiliation)parameter).Affiliation, ((ServiceWithAffiliation)parameter).Service.Id);
			AccommodationServicesViewModel.HomePageViewModel.ActivePage = new ServicesView(AccommodationServicesViewModel.HomePageViewModel);
		}
	}
}
