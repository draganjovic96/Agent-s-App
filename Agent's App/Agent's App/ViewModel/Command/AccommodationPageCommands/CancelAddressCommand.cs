using Agent_s_App.ViewModel.AccommodationPageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.AccommodationPageCommands
{
	public class CancelAddressCommand : ICommand
	{
		public AddressViewModel AddressViewModel { get; set; }

		public CancelAddressCommand(AddressViewModel addressViewModel)
		{
			AddressViewModel = addressViewModel;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			AddressViewModel.AccommodationPageViewModel.AgentViewModel.setAccommodationProfilePage();
		}
	}
}
