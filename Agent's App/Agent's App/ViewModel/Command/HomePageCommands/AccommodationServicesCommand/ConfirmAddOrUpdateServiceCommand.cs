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
			Random rnd = new Random();
			Core.Model.AccommodationService service = new Core.Model.AccommodationService();
			if(Service == null) service.Id = rnd.Next(456727);
			else service.Id = Service.Id;
			service.Name = AccommodationServiceViewModel.Name;
			service.Description = AccommodationServiceViewModel.Description;
			AccommodationServiceViewModel.AccommodationServicesViewModel.AccommodationServiceService.AddService(service);
			AccommodationServiceViewModel.AccommodationServicesViewModel.HomePageViewModel.ActivePage = new ServicesView(AccommodationServiceViewModel.AccommodationServicesViewModel.HomePageViewModel);
		}
	}
}
