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
	public class UpdateServiceCommand : ICommand
	{
		public AccommodationServicesViewModel AccommodationServicesViewModel { get; set; }

		public UpdateServiceCommand(AccommodationServicesViewModel accommodationServicesViewModel)
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
			AccommodationServicesViewModel.ServicePage = new ServiceView(AccommodationServicesViewModel.ServiceWithAffiliation.Service,  AccommodationServicesViewModel);
		}
	}
}
