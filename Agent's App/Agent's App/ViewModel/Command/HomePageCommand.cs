using Agent_s_App.Service;
using Agent_s_App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command
{
	public class HomePageCommand : ICommand
	{
		public AgentViewModel AgentViewModel { get; set; }

		public AccommodationUnitService accommodationUnitService = new AccommodationUnitService();

		public HomePageCommand(AgentViewModel agentViewModel)
		{
			AgentViewModel = agentViewModel;
		}
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			AgentViewModel.setHomePage(new HomePageView(AgentViewModel.LoggedUser, AgentViewModel.Accommodation, AgentViewModel));
			AgentViewModel.Accommodation.AccommodationUnits.ToList().AddRange(accommodationUnitService.GetAccommodationUnits(AgentViewModel.Accommodation.Id));
		}
	}
}
