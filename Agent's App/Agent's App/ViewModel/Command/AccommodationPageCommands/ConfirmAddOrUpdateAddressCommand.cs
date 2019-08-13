using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using Agent_s_App.ViewModel.AccommodationPageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;

namespace Agent_s_App.ViewModel.Command.AccommodationPageCommands
{
	public class ConfirmAddOrUpdateAddressCommand : ICommand
	{
		public AddressViewModel AddressViewModel { get; set; }
		public Service.AccommodationService AccommodationService = new Service.AccommodationService();
		public UserService UserService = new UserService();

		public ConfirmAddOrUpdateAddressCommand(AddressViewModel addressViewModel)
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
			Random rnd = new Random();
			Address address = new Address
			{
				Country = AddressViewModel.Country,
				City = AddressViewModel.City,
				Street = AddressViewModel.Street,
				Number = AddressViewModel.Number,
				ApartmentNumber = AddressViewModel.ApartmentNumber,
				Latitude = rnd.NextDouble() * (90 - (-90)) + (-90),
				Longitude = rnd.NextDouble() * (180 - (-180)) + (-180)
			};

			if (AddressViewModel.UserViewModel == null)
			{
				AddressViewModel.AccommodationPageViewModel.AgentViewModel.Accommodation.Address = address;
				AddressViewModel.AccommodationPageViewModel.AgentViewModel.setAccommodationProfilePage();
			}
			else
			{
				AddressViewModel.UserViewModel.AgentViewModel.LoggedUser.Address = address;
				AddressViewModel.UserViewModel.AgentViewModel.setUserPage();
			}
		}
	}
}
