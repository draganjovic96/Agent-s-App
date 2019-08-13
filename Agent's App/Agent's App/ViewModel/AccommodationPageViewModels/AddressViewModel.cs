using Agent_s_App.Core.Model;
using Agent_s_App.ViewModel.Command.AccommodationPageCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ViewModel.AccommodationPageViewModels
{
	public class AddressViewModel : ViewModelBase
	{
		private string link;
		private string country;
		private string city;
		private string street;
		private string number;
		private string apartmentNumber;
		private string addOrUpdateButton;

		public string Country
		{
			get => country;
			set
			{
				country = value;
				OnPropertyChanged("Country");
				setLink();
			}
		}
		public string City
		{
			get => city;
			set
			{
				city = value;
				OnPropertyChanged("City");
				setLink();
			}
		}
		public string Street
		{
			get => street;
			set
			{
				street = value;
				OnPropertyChanged("Street");
				setLink();
			}
		}
		public string Number
		{
			get => number;
			set
			{
				number = value;
				OnPropertyChanged("Number");
				setLink();
			}
		}
		public string ApartmentNumber
		{
			get => apartmentNumber;
			set
			{
				apartmentNumber = value;
				OnPropertyChanged("ApartmentNumber");
			}
		}
		public string Link
		{
			get => link;
			set
			{
				link = value;
				OnPropertyChanged("Link");
			}
		}
		public void setLink()
		{
			if(Street != null && Street != "" && 
				Number != null && Number != "" && 
				City != null && City !="" && 
				Country != null && Country != "")
			Link = "http://maps.google.com/maps?q=" + Street + " " + Number + "," + "+" + City + "," + "+" + Country;
		}
		public AccommodationPageViewModel AccommodationPageViewModel { get; set; }
		public UserViewModel UserViewModel { get; set; }
		public Address Address { get; set; }
		public string AddOrUpdateButton
		{
			get => addOrUpdateButton;
			set
			{
				addOrUpdateButton = value;
				OnPropertyChanged("AddOrUpdateButton");
			}
		}

		public ConfirmAddOrUpdateAddressCommand AddOrUpdateAddress { get; set; }
		public CancelAddressCommand CancelAddress { get; set; }

		public AddressViewModel(AccommodationPageViewModel accommodationPageViewModel, UserViewModel userViewModel)
		{
			CancelAddress = new CancelAddressCommand(this);
			AddOrUpdateAddress = new ConfirmAddOrUpdateAddressCommand(this);
			AccommodationPageViewModel = accommodationPageViewModel;
			UserViewModel = userViewModel;

			if (UserViewModel == null)
				Address = AccommodationPageViewModel.Accommodation.Address;
			else
				Address = UserViewModel.AgentViewModel.LoggedUser.Address;

			Country = Address.Country;
			City = Address.City;
			Street = Address.Street;
			Number = Address.Number;
			ApartmentNumber = Address.ApartmentNumber;
			if (Address.Id == 0) AddOrUpdateButton = "Add";
			else AddOrUpdateButton = "Update";
		}
	}
}
