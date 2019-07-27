using Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationServicesCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ViewModel.HomePageViewModels
{
	public class AccommodationServiceViewModel : ViewModelBase
	{
		private string name;
		private string description;

		public AccommodationServicesViewModel AccommodationServicesViewModel { get; set; }
		public Core.Model.AccommodationService Service { get; set; }
		public ConfirmAddOrUpdateServiceCommand ConfirmAddOrUpdateServiceCommand { get; set; }
		public CancelServiceCommand CancelServiceCommand { get; set; }
		public string AddOrSaveButton { get; set; }

		public AccommodationServiceViewModel(Core.Model.AccommodationService service, AccommodationServicesViewModel accommodationServicesViewModel)
		{
			AccommodationServicesViewModel = accommodationServicesViewModel;
			AddOrSaveButton = "Add";
			if (service != null)
			{
				AddOrSaveButton = "Save";
				Service = service;
				Name = Service.Name;
				Description = Service.Description;
			}
			ConfirmAddOrUpdateServiceCommand = new ConfirmAddOrUpdateServiceCommand(this);
			CancelServiceCommand = new CancelServiceCommand(this);
		}

		public string Name
		{
			get => name;
			set
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}

		public string Description
		{
			get => description;
			set
			{
				description = value;
				OnPropertyChanged("Description");
			}
		}

	}
}
