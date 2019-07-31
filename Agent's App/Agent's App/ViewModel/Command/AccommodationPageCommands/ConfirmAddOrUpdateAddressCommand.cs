using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using Agent_s_App.ViewModel.AccommodationPageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.AccommodationPageCommands
{
	public class ConfirmAddOrUpdateAddressCommand : ICommand
	{
		public AddressViewModel AddressViewModel { get; set; }
		public AddressService AddressService = new AddressService();
		public Service.AccommodationService AccommodationService = new Service.AccommodationService();
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
			Address address = new Address();
			if (AddressViewModel.Address.Id == 0) address.Id = rnd.Next(1123213);
			else address.Id = AddressViewModel.Address.Id;
			address.Country = AddressViewModel.Country;
			address.City = AddressViewModel.City;
			address.Street = AddressViewModel.Street;
			address.Number = AddressViewModel.Number;
			address.ApartmentNumber = AddressViewModel.ApartmentNumber;
			AddressService.AddAddress(address);
			AddressViewModel.AccommodationPageViewModel.AgentViewModel.Accommodation = AccommodationService.GetAccommodationByUsername(AddressViewModel.AccommodationPageViewModel.AgentViewModel.LoggedUser.Username);
			AddressViewModel.AccommodationPageViewModel.AgentViewModel.setAccommodationProfilePage();
		}
	}
}
