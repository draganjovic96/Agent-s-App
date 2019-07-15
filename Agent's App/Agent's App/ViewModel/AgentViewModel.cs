using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Agent_s_App.ViewModel
{
	public class AgentViewModel : ViewModelBase
	{
		private User loggedUser;
		private string homePageButton;
		private string messengerButton;
		private string accommodationProfileButton;
		private string agentProfileButton;
		private UserControl activePage;
		private Service.AccommodationService accommodationService = new Service.AccommodationService();

		//public AccommodationProfileCommand AccommodationProfileCommand { get; set; }
		//public HomePageCommand HomePageCommand { get; set; }

		public AgentViewModel(User user)
		{
			Console.WriteLine(user.Username);
			LoggedUser = user;
			//AccommodationProfileCommand = new AccommodationProfileCommand(this);
			//HomePageCommand = new HomePageCommand(this);

			//Accommodation accommodation = accommodationService.getAccommodationByUserId(LoggedUser);
			//if (accommodation != null)
			//{
				HomePageButton = "Resources/home_page_active.png";
			//	ActivePage = new HomePage(LoggedUser);
			//}
			//else
			//{
			//	AccommodationProfileButton = "Resources/accommodation_active.png";
			//	ActivePage = new AccommodationProfile(LoggedUser);
			//}
		}

		public User LoggedUser
		{
			get => loggedUser;
			set
			{
				loggedUser = value;
				OnPropertyChanged("LoggedUser");
			}
		}

		public string HomePageButton
		{
			get => homePageButton;
			set
			{
				homePageButton = value;
				messengerButton = "Resources/messenger_deactive.png";
				accommodationProfileButton = "Resources/accommodation_deactive.png";
				agentProfileButton = "Resources/agent_profile_deactive.png";
				OnPropertyChanged("HomePageButton");
				OnPropertyChanged("MessengerButton");
				OnPropertyChanged("AccommodationProfileButton");
				OnPropertyChanged("AgentProfileButton");
			}
		}

		public string MessengerButton
		{
			get => messengerButton;
			set
			{
				messengerButton = value;
				homePageButton = "Resources/home_page_deactive.png";
				OnPropertyChanged("HomePageButton");
				OnPropertyChanged("MessengerButton");
				OnPropertyChanged("AccommodationProfileButton");
				OnPropertyChanged("AgentProfileButton");
			}
		}

		public string AccommodationProfileButton
		{
			get => accommodationProfileButton;
			set
			{
				accommodationProfileButton = value;
				messengerButton = "Resources/messenger_deactive.png";
				homePageButton = "Resources/home_page_deactive.png";
				agentProfileButton = "Resources/agent_profile_deactive.png";
				OnPropertyChanged("HomePageButton");
				OnPropertyChanged("MessengerButton");
				OnPropertyChanged("AccommodationProfileButton");
				OnPropertyChanged("AgentProfileButton");
			}
		}

		public string AgentProfileButton
		{
			get => agentProfileButton;
			set
			{
				agentProfileButton = value;
				OnPropertyChanged("HomePageButton");
				OnPropertyChanged("MessengerButton");
				OnPropertyChanged("AccommodationProfileButton");
				OnPropertyChanged("AgentProfileButton");
			}
		}

		public UserControl ActivePage
		{
			get => activePage;
			set
			{
				activePage = value;
				OnPropertyChanged("ActivePage");
			}
		}

		internal void setAccommodationProfilePage(UserControl page)
		{
			ActivePage = page;
			AccommodationProfileButton = "Resources/accommodation_active.png";
		}

		internal void setHomePage(UserControl page)
		{
			ActivePage = page;
			homePageButton = "Resources/home_page_active.png";
		}
	}
}
