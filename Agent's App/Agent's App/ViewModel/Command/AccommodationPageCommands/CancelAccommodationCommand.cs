using Agent_s_App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.AccommodationPageCommands
{
	public class CancelAccommodationCommand : ICommand
	{
		public AccommodationPageViewModel AccommodationPageViewModel { get; set; }

		private AccommodationService accommodationService = new AccommodationService();

		public CancelAccommodationCommand(AccommodationPageViewModel accommodationPageViewModel)
		{
			AccommodationPageViewModel = accommodationPageViewModel;
		}
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			AccommodationPageViewModel.AgentViewModel.Accommodation = accommodationService.GetAccommodationByUsername(AccommodationPageViewModel.AgentViewModel.LoggedUser.Username);
			AccommodationPageViewModel.AgentViewModel.setAccommodationProfilePage();
		}
	}
}
