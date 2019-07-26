using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using Agent_s_App.ViewModel.Command.HomePageCommands.ReservationCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ViewModel.HomePageViewModels
{
	public class ReservationsViewModel : ViewModelBase
	{
		private Reservation reservation = null;

		public AccommodationUnit Unit { get; set; }
		public ReservationService ReservationService = new ReservationService();
		public HomePageViewModel HomePageViewModel { get; set; }
		public List<Reservation> Reservations { get; set; }
		public string UnitString { get; set; }

		public AddReservationCommand AddReservationCommand { get; set; }

		public ReservationsViewModel(AccommodationUnit unit, HomePageViewModel homePageViewModel)
		{
			HomePageViewModel = homePageViewModel;
			if (unit != null)
			{
				Unit = unit;
				Reservations = ReservationService.GetReservations(Unit.Id, Unit.Accommodation.Id);
				UnitString = "Floor : " + Unit.Floor + ", Number : " + Unit.Number;
			}
			else
			{
				Reservations = ReservationService.GetReservations(0, HomePageViewModel.Accommodation.Id);

			}
			AddReservationCommand = new AddReservationCommand(Unit, Reservation, this);
		}

		public Reservation Reservation
		{
			get => reservation;
			set
			{
				reservation = value;
				OnPropertyChanged("Reservation");
			}
		}

	}
}
