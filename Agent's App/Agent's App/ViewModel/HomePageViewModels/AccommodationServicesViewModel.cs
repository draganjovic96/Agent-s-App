using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationServicesCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Agent_s_App.ViewModel.HomePageViewModels
{
	public class ServiceWithAffiliation
	{
		private Core.Model.AccommodationService service;

		public Accommodation Accommodation { get; set; }

		public Core.Model.AccommodationService Service
		{
			get => service;
			set
			{
				service = value;
				Affiliation = setAffiliation();
			}
		}

		public bool Affiliation { get; set; }

		public SaveServiceAffiliationCommand SaveServiceAffiliationCommand { get; set; }

		public bool setAffiliation()
		{
			foreach (Accommodation accommodation in Service.Accommodations)
				if (accommodation.Id == Accommodation.Id)
					return true;
			return false;
		}

		public ServiceWithAffiliation(Accommodation accommodation, Core.Model.AccommodationService service, AccommodationServicesViewModel accommodationServicesViewModel)
		{
			Accommodation = accommodation;
			Service = service;
			SaveServiceAffiliationCommand = new SaveServiceAffiliationCommand(accommodationServicesViewModel);
		}
	}

	public class AccommodationServicesViewModel : ViewModelBase
	{
		
		private ServiceWithAffiliation serviceWithAffiliation;
		private UserControl servicePage;
		private bool enableUpdate;

		public AccommodationServiceService AccommodationServiceService = new AccommodationServiceService();
		public HomePageViewModel HomePageViewModel { get; set; }
		public List<ServiceWithAffiliation> Services { get; set; }
		
		public AddServiceCommand AddServiceCommand { get; set; }
		public UpdateServiceCommand UpdateServiceCommand { get; set; }
		public DeleteServiceCommand DeleteServiceCommand { get; set; }

		public AccommodationServicesViewModel(HomePageViewModel homePageViewModel)
		{
			HomePageViewModel = homePageViewModel;
			List<ServiceWithAffiliation> services = new List<ServiceWithAffiliation>();
			foreach(Core.Model.AccommodationService s in AccommodationServiceService.GetAllAccommodationServices(HomePageViewModel.Accommodation.Id))
			{
				services.Add(new ServiceWithAffiliation(HomePageViewModel.Accommodation, s, this));
			}
			Services = services;
			AddServiceCommand = new AddServiceCommand(this);
			UpdateServiceCommand = new UpdateServiceCommand(this);
			DeleteServiceCommand = new DeleteServiceCommand(this);
		}

		public ServiceWithAffiliation ServiceWithAffiliation
		{
			get => serviceWithAffiliation;
			set
			{
				serviceWithAffiliation = value;
				EnableUpdate = IsEnableUpdate();
				ServicePage = null;
				OnPropertyChanged("ServiceWithAffiliation");
			}
		}

		public UserControl ServicePage
		{
			get => servicePage;
			set
			{
				servicePage = value;
				OnPropertyChanged("ServicePage");
			}
		}

		public bool EnableUpdate
		{
			get => enableUpdate;
			set
			{
				enableUpdate = value;
				OnPropertyChanged("EnableUpdate");
			}
		}

		public bool IsEnableUpdate()
		{
			List<Accommodation> accommodations = AccommodationServiceService.GetServiceAccommodations(ServiceWithAffiliation.Service.Id);
			if ((accommodations.Count == 1 && accommodations.First().Id == HomePageViewModel.Accommodation.Id) ||
				(accommodations == null) || (accommodations.Count == 0)) return true;
			else return false;
		}
	}
}
