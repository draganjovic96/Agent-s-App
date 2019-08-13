using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.AccommodationPageCommands
{
	public class ConfirmAddOrUpdateAccommodationCommand : ICommand
	{
		public AccommodationPageViewModel AccommodationPageViewModel { get; set; }
		public Service.AccommodationService AccommodationService = new Service.AccommodationService();
		
		public ConfirmAddOrUpdateAccommodationCommand(AccommodationPageViewModel accommodationPageViewModel)
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
			Accommodation accommodation = new Accommodation();
			accommodation = AccommodationPageViewModel.AgentViewModel.Accommodation;
			accommodation.Name = AccommodationPageViewModel.Name;
			accommodation.AccommodationType = AccommodationPageViewModel.Type;
			accommodation.Category = AccommodationPageViewModel.Category;
			accommodation.Description = AccommodationPageViewModel.Description;

			if (AccommodationPageViewModel.AddOrUpdateButton.Equals("Add"))
			{
				AccommodationService.AddAccommodation(accommodation, AccommodationPageViewModel.AgentViewModel.LoggedUser);
			}
			else
			{
				AccommodationService.UpdateAccommodation(accommodation);
			}
			AccommodationPageViewModel.AgentViewModel.Accommodation = AccommodationService.GetAccommodationByUsername(AccommodationPageViewModel.AgentViewModel.LoggedUser.Username);
			AccommodationPageViewModel.AgentViewModel.AccommodationLabel = AccommodationPageViewModel.AgentViewModel.Accommodation.Name;
			AccommodationPageViewModel.AgentViewModel.setAccommodationProfilePage();
		}
	}
}
