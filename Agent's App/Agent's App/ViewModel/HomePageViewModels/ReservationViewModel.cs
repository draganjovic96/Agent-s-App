﻿using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using Agent_s_App.View.HomePageViews;
using Agent_s_App.ViewModel.Command.HomePageCommands.ReservationCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Agent_s_App.ViewModel.HomePageViewModels
{
	public class ReservationViewModel : ViewModelBase
	{
		private AccommodationUnit unit;
		private DateTime fromDate;
		private DateTime toDate;
		private bool agentConfirmed;
		private bool enableEdit;
		private bool enableMessages;
		private bool enableUnit;
		private double price;

		public AccommodationUnitService accommodationUnitService = new AccommodationUnitService();
		public HomePageViewModel HomePageViewModel { get; set; }
		public ReservationsViewModel ReservationsViewModel { get; set; }
		public bool UserConfirmed { get; set; }
		public UserControl CommentRatePage { get; set; }
		public User Guest { get; set; }
		public List<AccommodationUnit> Units { get; set; }
		public Reservation Reservation { get; set; }
		public ConfirmAddOrUpdateReservationCommand ConfirmAddOrUpdateReservationCommand { get; set; }
		public CancelAddOrUpdateReservationCommand CancelAddOrUpdateReservationCommand { get; set; }
		public string AddOrSaveButton { get; set; }
		public ReservationService ReservationService = new ReservationService();
		public GetMessagesByReservationCommand GetMessagesByReservationCommand { get; set; }

		public ReservationViewModel(Reservation reservation, ReservationsViewModel reservationsViewModel)
		{
			EnableEdit = true;
			EnableUnit = true;
			HomePageViewModel = reservationsViewModel.HomePageViewModel;
			Units = accommodationUnitService.GetAccommodationUnits(HomePageViewModel.Accommodation.Id);
			ReservationsViewModel = reservationsViewModel;
			CommentRatePage = new NoCommentRateView();

			if (reservationsViewModel.Unit != null)
			{
				EnableUnit = false;
				Unit = ReservationsViewModel.Unit;
			}

			if (reservation != null)
			{
				AddOrSaveButton = "Save";
				Reservation = reservation;
				Guest = reservation.Guest;
				FromDate = reservation.FromDate;
				ToDate = reservation.ToDate;
				UserConfirmed = reservation.Confirmed;
				AgentConfirmed = reservation.AgentConfirmed;
				Price = reservation.Price;
				if (Guest.Id != HomePageViewModel.LoggedUser.Id)
				{
					EnableEdit = false;
					CommentRatePage = new CommentRateView(reservationsViewModel);
				}
				EnableUnit = false;
				Unit = reservation.AccommodationUnit;
				GetMessagesByReservationCommand = new GetMessagesByReservationCommand(Reservation.Id, this);
			}
			else
			{
				FromDate = new DateTime(2001, 1, 1);
				ToDate = new DateTime(2001, 1, 1);
				AddOrSaveButton = "Add";
				Guest = HomePageViewModel.LoggedUser;
				Reservation = new Reservation();
			}
			ConfirmAddOrUpdateReservationCommand = new ConfirmAddOrUpdateReservationCommand(this);
			CancelAddOrUpdateReservationCommand = new CancelAddOrUpdateReservationCommand(ReservationsViewModel);
		}

		public AccommodationUnit Unit
		{
			get => unit;
			set
			{
				unit = value;
				if (Unit != null && FromDate != null && ToDate != null)
				{
					Reservation.AccommodationUnit = Unit;
					Reservation.FromDate = FromDate;
					Reservation.ToDate = ToDate;
					Price = ReservationService.setPrice(Reservation);
				}
				OnPropertyChanged("Unit");
			}
		}

		public DateTime FromDate
		{
			get => fromDate;
			set
			{
				fromDate = value;
				if (Unit != null && FromDate != null && ToDate != null)
				{
					Reservation.AccommodationUnit = Unit;
					Reservation.FromDate = FromDate;
					Reservation.ToDate = ToDate;
					Price = ReservationService.setPrice(Reservation);
				}
				OnPropertyChanged("FromDate");
			}
		}

		public DateTime ToDate
		{
			get => toDate;
			set
			{
				toDate = value;
				if (Unit != null && FromDate != null && ToDate != null)
				{
					Reservation.AccommodationUnit = Unit;
					Reservation.FromDate = FromDate;
					Reservation.ToDate = ToDate;
					Price = ReservationService.setPrice(Reservation);
				}
				OnPropertyChanged("ToDate");
			}
		}

		public bool AgentConfirmed
		{
			get => agentConfirmed;
			set
			{
				agentConfirmed = value;
				OnPropertyChanged("AgentConfirmed");
			}
		}

		public bool EnableEdit
		{
			get => enableEdit;
			set
			{
				enableEdit = value;
				EnableMessages = !value;
				OnPropertyChanged("EnableEdit");
			}
		}

		public bool EnableMessages
		{
			get => enableMessages;
			set
			{
				enableMessages = value;
				OnPropertyChanged("EnableMessages");
			}
		}

		public bool EnableUnit
		{ 
			get => enableUnit;
			set
			{
				enableUnit = value;
				OnPropertyChanged("EnableUnit");
			}
		}

		public double Price
		{
			get => price;
			set
			{
				price = value;
				OnPropertyChanged("Price");
			}
		}
	}
}
