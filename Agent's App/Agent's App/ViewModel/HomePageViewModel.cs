using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Agent_s_App.ViewModel
{
	public class HomePageViewModel : ViewModelBase
	{
		private Service.AccommodationService accommodationService = new Service.AccommodationService();
		//private Service.AccommodationUnitService unitService = new Service.AccommodationUnitService();

		private string unitsButtonColor;
		private string commentsButtonColor;
		private string reservationsButtonColor;
		private string servicesButtonColor;
		private User loggedUser;
		private Accommodation accommodation;

		//public UnitsPageCommand UnitsPageCommand { get; set; }
		//public ReservationsPageCommand ReservationsPageCommand { get; set; }

		private UserControl activePage;

		public HomePageViewModel(User loggedUser)
		{
			LoggedUser = loggedUser;
			//Accommodation = accommodationService.getAccommodationByUserId(LoggedUser);
			//UnitsPageCommand = new UnitsPageCommand(this);
			//ReservationsPageCommand = new ReservationsPageCommand(this);
			UnitsButtonColor = "Green";
			//ActivePage = new Units(LoggedUser);
		}

		public string UnitsButtonColor
		{
			get { return unitsButtonColor; }
			set
			{
				this.unitsButtonColor = value;
				this.commentsButtonColor = "Transparent";
				this.reservationsButtonColor = "Transparent";
				this.servicesButtonColor = "Transparent";
				OnPropertyChanged("UnitsButtonColor");
				OnPropertyChanged("ReservationsButtonColor");

			}
		}

		public string CommentsButtonColor
		{
			get { return commentsButtonColor; }
			set
			{
				this.unitsButtonColor = "Transparent";
				this.commentsButtonColor = value;
				this.reservationsButtonColor = "Transparent";
				this.servicesButtonColor = "Transparent";
				OnPropertyChanged("CommentsButtonColor");
			}
		}

		public string ReservationsButtonColor
		{
			get { return reservationsButtonColor; }
			set
			{
				this.unitsButtonColor = "Transparent";
				this.commentsButtonColor = "Transparent";
				this.reservationsButtonColor = value;
				this.servicesButtonColor = "Transparent";
				OnPropertyChanged("ReservationsButtonColor");
				OnPropertyChanged("UnitsButtonColor");

			}
		}

		public string ServicesButtonColor
		{
			get { return servicesButtonColor; }
			set
			{
				this.unitsButtonColor = "Transparent";
				this.commentsButtonColor = "Transparent";
				this.reservationsButtonColor = "Transparent";
				this.servicesButtonColor = value;
				OnPropertyChanged("ServicesButtonColor");
			}
		}

		public UserControl ActivePage
		{
			get => activePage;
			set
			{
				this.activePage = value;
				OnPropertyChanged("ActivePage");
			}
		}

		public void setUnitsPage()
		{
			//ActivePage = new Units(LoggedUser);
			UnitsButtonColor = "Green";
		}


		public void setReservationsPage()
		{
			//ActivePage = new Reservations(Accommodation);
			ReservationsButtonColor = "Green";
		}

		public User LoggedUser { get => loggedUser; set => loggedUser = value; }
		public Accommodation Accommodation { get => accommodation; set => accommodation = value; }
	}
}
