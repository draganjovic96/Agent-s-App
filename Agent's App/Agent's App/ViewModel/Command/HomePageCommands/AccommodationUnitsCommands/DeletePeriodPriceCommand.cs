﻿using Agent_s_App.Service;
using Agent_s_App.View.HomePageViews;
using Agent_s_App.ViewModel.HomePageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationUnitsCommands
{
	public class DeletePeriodPriceCommand : ICommand
	{
		private PeriodPriceService periodPriceService = new PeriodPriceService();

		public PeriodPricesViewModel PeriodPricesViewModel { get; set; }
		public HomePageViewModel HomePageViewModel { get; set; }

		public DeletePeriodPriceCommand(PeriodPricesViewModel periodPricesViewModel, HomePageViewModel homePageViewModel)
		{
			PeriodPricesViewModel = periodPricesViewModel;
			HomePageViewModel = homePageViewModel;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			if (periodPriceService.DeletePeriodPrice(PeriodPricesViewModel.PeriodPrice.Id)) MessageBox.Show("Period price, with " + PeriodPricesViewModel.PeriodPrice.Id + " ID, deleted.");
			else MessageBox.Show("Can't delete eriod price with " + PeriodPricesViewModel.PeriodPrice.Id + " ID.");

			HomePageViewModel.ActivePage = new PeriodPricesView(HomePageViewModel, PeriodPricesViewModel.AccommodationUnit);
		}
	}
}
