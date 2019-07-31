using Agent_s_App.View.AccommodationPageViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.AccommodationPageCommands
{
	public class AddressPageCommand : ICommand
	{
		public AccommodationPageViewModel AccommodationPageViewModel { get; set; }

		public AddressPageCommand(AccommodationPageViewModel accommodationPageViewModel)
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
			AccommodationPageViewModel.AgentViewModel.ActivePage = new AddressView(AccommodationPageViewModel);
		}
	}
}
