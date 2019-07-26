using Agent_s_App.Core.Model;
using Agent_s_App.View.HomePageViews;
using Agent_s_App.ViewModel.Command.HomePageCommands;
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
		private string unitsButtonColor;
		private string unitTypesButtonColor;
		private string commentsButtonColor;
		private string reservationsButtonColor;
		private string servicesButtonColor;
		private User loggedUser;
		private Accommodation accommodation;

		public UnitsPageCommand UnitsPageCommand { get; set; }
		public UnitTypesPageCommand UnitTypesPageCommand { get; set; }
		public ReservationsPageCommand ReservationsPageCommand { get; set; }
		private UserControl activePage;

		public HomePageViewModel(User loggedUser, Accommodation accommodation)
		{
			if (accommodation != null)
			{
				Accommodation = accommodation;
				setUnitsPage();
			}
			else
			{
				Accommodation = new Accommodation();
				setUnitTypesPage();
			}
			LoggedUser = loggedUser;
			UnitsPageCommand = new UnitsPageCommand(this);
			UnitTypesPageCommand = new UnitTypesPageCommand(this);
			ReservationsPageCommand = new ReservationsPageCommand(null, this);
		}

		public string UnitsButtonColor
		{
			get { return unitsButtonColor; }
			set
			{
				this.unitsButtonColor = value;
				this.unitTypesButtonColor = "Transparent";
				this.reservationsButtonColor = "Transparent";
				OnPropertyChanged("UnitsButtonColor");
				OnPropertyChanged("UnitTypesButtonColor");
				OnPropertyChanged("ReservationsButtonColor");
			}
		}

		public string UnitTypesButtonColor
		{
			get => unitTypesButtonColor;
			set
			{
				this.unitTypesButtonColor = value;
				this.unitsButtonColor = "Transparent";
				this.reservationsButtonColor = "Transparent";
				OnPropertyChanged("UnitsButtonColor");
				OnPropertyChanged("UnitTypesButtonColor");
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
				this.unitTypesButtonColor = "Transparent";
				this.commentsButtonColor = "Transparent";
				this.reservationsButtonColor = value;
				this.servicesButtonColor = "Transparent";
				OnPropertyChanged("ReservationsButtonColor");
				OnPropertyChanged("UnitsButtonColor");
				OnPropertyChanged("UnitTypesButtonColor");
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
			ActivePage = new UnitsView(accommodation, this);
			UnitsButtonColor = "Green";
		}

		public void setUnitTypesPage()
		{
			ActivePage = new UnitTypesView(accommodation, this);
			UnitTypesButtonColor = "Green";
		}

		public void setReservationsPage(AccommodationUnit unit)
		{
			ActivePage = new ReservationsView(unit, this);
			ReservationsButtonColor = "Green";
		}

		public void setUnitPage(AccommodationUnit accommodationUnit)
		{
			ActivePage = new UnitView(accommodationUnit, this);
		}

		public User LoggedUser
		{
			get => loggedUser;
			set => loggedUser = value;
		}

		public Accommodation Accommodation
		{
			get => accommodation;
			set => accommodation = value;
		}
	}
}
