using Agent_s_App.ViewModel.HomePageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationServicesCommand
{
	public class CancelServiceCommand : ICommand
	{
		public AccommodationServiceViewModel AccommodationServiceViewModel { get; set; }
		public CancelServiceCommand(AccommodationServiceViewModel accommodationServiceViewModel)
		{
			AccommodationServiceViewModel = accommodationServiceViewModel;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			AccommodationServiceViewModel.AccommodationServicesViewModel.ServicePage = null;
		}
	}
}
