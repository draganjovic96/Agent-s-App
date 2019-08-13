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
		private string userProfileButton;
		private UserControl activePage;
		private Service.AccommodationService accommodationService = new Service.AccommodationService();

		public MainViewModel MainViewModel { get; set; }
		public HomePageCommand HomePageCommand { get; set; }
		public MessagesPageCommand MessagesPageCommand { get; set; }
		public AccommodationPageCommand AccommodationPageCommand { get; set; }
		public UserPageCommand UserPageCommand { get; set; }
		public LogoutCommand LogoutCommand { get; set; }

		public AgentViewModel(User user, MainViewModel mainViewModel)
		{
			MainViewModel = mainViewModel;
			LoggedUser = user;
			HomePageCommand = new HomePageCommand(this);
			MessagesPageCommand = new MessagesPageCommand(this);
			AccommodationPageCommand = new AccommodationPageCommand(this);
			UserPageCommand = new UserPageCommand(this);
			LogoutCommand = new LogoutCommand(this);

			Accommodation = accommodationService.GetAccommodationByUsername(LoggedUser.Username);
			if (Accommodation == null)
			{
				Accommodation = new Accommodation();
				Accommodation.Address = new Address();
			}
			if (Accommodation.Id != 0)
			{
				HomePageCommand.Execute(null);
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
				if (accommodation != null && accommodation.Id != 0)
				{
					setAddressLabel();
					AccommodationLabel = value.Name;
				}
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
				userProfileButton = "Resources/agent_profile_deactive.png";
				OnPropertyChanged("HomePageButton");
				OnPropertyChanged("MessengerButton");
				OnPropertyChanged("AccommodationProfileButton");
				OnPropertyChanged("UserProfileButton");
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
				userProfileButton = "Resources/agent_profile_deactive.png";
				OnPropertyChanged("HomePageButton");
				OnPropertyChanged("MessengerButton");
				OnPropertyChanged("AccommodationProfileButton");
				OnPropertyChanged("UserProfileButton");
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
				userProfileButton = "Resources/agent_profile_deactive.png";
				OnPropertyChanged("HomePageButton");
				OnPropertyChanged("MessengerButton");
				OnPropertyChanged("AccommodationProfileButton");
				OnPropertyChanged("UserProfileButton");
			}
		}

		public string UserProfileButton
		{
			get => userProfileButton;
			set
			{
				userProfileButton = value;
				accommodationProfileButton = "Resources/accommodation_deactive.png";
				messengerButton = "Resources/messenger_deactive.png";
				homePageButton = "Resources/home_page_deactive.png";
				OnPropertyChanged("HomePageButton");
				OnPropertyChanged("MessengerButton");
				OnPropertyChanged("AccommodationProfileButton");
				OnPropertyChanged("UserProfileButton");
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

		public void setUserPage()
		{
			ActivePage = new UserPageView(this);
			UserProfileButton = "Resources/agent_profile_active.png";
		}

		public void setAddressLabel()
		{
			AddressLabel = Accommodation.Address.Street + " " + Accommodation.Address.Number + ", " + Accommodation.Address.City;

		}
	}
}
