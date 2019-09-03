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
	public class ConfirmAddOrUpdateServiceCommand : ICommand
	{
		public AccommodationServiceViewModel AccommodationServiceViewModel { get; set; }
		public Core.Model.AccommodationService Service { get; set; }

		public ConfirmAddOrUpdateServiceCommand(AccommodationServiceViewModel accommodationServiceViewModel)
		{
			AccommodationServiceViewModel = accommodationServiceViewModel;
			Service = AccommodationServiceViewModel.Service;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			Core.Model.AccommodationService service = new Core.Model.AccommodationService();
			service.Name = AccommodationServiceViewModel.Name;
			service.Description = AccommodationServiceViewModel.Description;
			if (AccommodationServiceViewModel.AddOrSaveButton.Equals("Add"))
				if (AccommodationServiceViewModel.AccommodationServicesViewModel.AccommodationServiceService.AddService(service))
					MessageBox.Show("Service added.");
				else
					MessageBox.Show("Can't add service.");
			else
			{
				service.Id = Service.Id;
				if(AccommodationServiceViewModel.AccommodationServicesViewModel.AccommodationServiceService.UpdateService(service))
					MessageBox.Show("Service, with " + Service.Id + " ID, updated."); 
				else
					MessageBox.Show("Can't update service with" + Service.Id + " ID.");

			}
			AccommodationServiceViewModel.AccommodationServicesViewModel.HomePageViewModel.ActivePage = new ServicesView(AccommodationServiceViewModel.AccommodationServicesViewModel.HomePageViewModel);
		}
	}
}
