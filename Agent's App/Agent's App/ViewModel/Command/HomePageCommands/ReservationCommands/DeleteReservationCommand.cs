﻿using Agent_s_App.View.HomePageViews;
using Agent_s_App.ViewModel.HomePageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.HomePageCommands.ReservationCommands
{
	public class DeleteReservationCommand : ICommand
	{
		public ReservationsViewModel ReservationsViewModel { get; set; }

		public DeleteReservationCommand(ReservationsViewModel reservationsViewModel)
		{
			ReservationsViewModel = reservationsViewModel;
		}
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			if (ReservationsViewModel.ReservationService.DeleteReservation(ReservationsViewModel.Reservation.Id))
				MessageBox.Show("Reservation with " + ReservationsViewModel.Reservation.Id + " ID deleted.");
			else
				MessageBox.Show("Can'd delete reservation with " + +ReservationsViewModel.Reservation.Id + " ID.");
			ReservationsViewModel.HomePageViewModel.ActivePage = new ReservationsView(ReservationsViewModel.Unit, ReservationsViewModel.HomePageViewModel);
		}
	}
}
