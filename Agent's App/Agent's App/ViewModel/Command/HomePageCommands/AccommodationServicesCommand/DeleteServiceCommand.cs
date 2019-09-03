using Agent_s_App.View.HomePageViews;
using Agent_s_App.ViewModel.HomePageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationServicesCommand
{
	public class DeleteServiceCommand : ICommand
	{
		public AccommodationServicesViewModel AccommodationServicesViewModel { get; set; }

		public DeleteServiceCommand(AccommodationServicesViewModel accommodationServicesViewModel)
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
			if(AccommodationServicesViewModel.AccommodationServiceService.DeleteService(AccommodationServicesViewModel.ServiceWithAffiliation.Service.Id))
				MessageBox.Show("Service, with " + AccommodationServicesViewModel.ServiceWithAffiliation.Service.Id + " ID, deleted.");
			else
				MessageBox.Show("Can't delete service with " + AccommodationServicesViewModel.ServiceWithAffiliation.Service.Id + " ID.");

			AccommodationServicesViewModel.HomePageViewModel.ActivePage = new ServicesView(AccommodationServicesViewModel.HomePageViewModel);
		}
	}
}
