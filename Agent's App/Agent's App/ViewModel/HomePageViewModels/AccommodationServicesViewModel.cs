using Agent_s_App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ViewModel.HomePageViewModels
{
	public class AccommodationServicesViewModel : ViewModelBase
	{
		public AccommodationServiceService AccommodationServiceService = new AccommodationServiceService();
		public HomePageViewModel HomePageViewModel { get; set; }
		public List<Core.Model.AccommodationService> Services { get; set; }

		public AccommodationServicesViewModel(HomePageViewModel homePageViewModel)
		{
			Services = AccommodationServiceService.GetAllAccommodationServices();
		}
	}
}
