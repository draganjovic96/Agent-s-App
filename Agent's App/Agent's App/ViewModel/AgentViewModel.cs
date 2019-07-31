using Agent_s_App.Core.Model;
using Agent_s_App.View;
using Agent_s_App.ViewModel.Command;
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
		private Accommodation accommodation;

		private string accommodationLabel;
		private string addressLabel;

		private string homePageButton;
		private string messengerButton;
		private string accommodationProfileButton;
		private string agentProfileButton;
		private UserControl activePage;
		private Service.AccommodationService accommodationService = new Service.AccommodationService();

		public HomePageCommand HomePageCommand { get; set; }
		public MessagesPageCommand MessagesPageCommand { get; set; }
		public AccommodationPageCommand AccommodationPageCommand { get; set; }

		public AgentViewModel(User user)
		{
			LoggedUser = user;
			HomePageCommand = new HomePageCommand(this);
			MessagesPageCommand = new MessagesPageCommand(this);
			AccommodationPageCommand = new AccommodationPageCommand(this);

			Accommodation = accommodationService.GetAccommodationByUsername(LoggedUser.Username);
			if (accommodation != null)
			{
				HomePageButton = "Resources/home_page_active.png";
				ActivePage = new HomePageView(LoggedUser, Accommodation);
				AccommodationLabel = Accommodation.Name;
				setAddressLabel();
			}
			else
			{
				setAccommodationProfilePage();
			}
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

		public Accommodation Accommodation
		{
			get => accommodation;
			set
			{
				accommodation = value;
				OnPropertyChanged("Accommodation");
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
				accommodationProfileButton = "Resources/accommodation_deactive.png";
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

		public string AccommodationLabel
		{
			get => accommodationLabel;
			set
			{
				accommodationLabel = value;
				OnPropertyChanged("AccommodationLabel");
			}
		}

		public string AddressLabel
		{
			get => addressLabel;
			set
			{
				addressLabel = value;
				OnPropertyChanged("AddressLabel");
			}
		}

		public void setAccommodationProfilePage()
		{
			ActivePage = new AccommodationPageView(this);
			AccommodationProfileButton = "Resources/accommodation_active.png";
		}

		public void setHomePage(UserControl page)
		{
			ActivePage = page;
			HomePageButton = "Resources/home_page_active.png";
		}

		public void setMessagesPage()
		{
			ActivePage = new MessagesView(this);
			MessengerButton = "Resources/messenger_active.png";
		}

		public void setAddressLabel()
		{
			AddressLabel = Accommodation.Address.Street + " " + Accommodation.Address.Number + ", " + Accommodation.Address.City;

		}
	}
}
