using Agent_s_App.Core.Model;
using Agent_s_App.ViewModel.Command.AccommodationPageCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ViewModel
{
	public class AccommodationPageViewModel : ViewModelBase
	{
		private string name;
		private string description;
		private AccommodationType accommodationType;
		private string country;
		private string city;
		private string street;
		private string number;
		private string apartmentNumber;
		private string category;

		public AgentViewModel AgentViewModel { get; set; }
		public List<AccommodationType> Types { get; set; } 
		public string Name
		{
			get => name;
			set
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}
		public string Description
		{
			get => description;
			set
			{
				description = value;
				OnPropertyChanged("Description");
			}
		}
		public AccommodationType Type
		{
			get => accommodationType;
			set
			{
				accommodationType = value;
				OnPropertyChanged("Type");
			}
		}
		public string Country
		{
			get => country;
			set
			{
				country = value;
			}
		}
		public string City
		{
			get => city;
			set
			{
				city = value;
			}
		}
		public string Street
		{
			get => street;
			set
			{
				street = value;
			}
		}
		public string Number
		{
			get => number;
			set
			{
				number = value;
			}
		}
		public string ApartmentNumber
		{
			get => apartmentNumber;
			set
			{
				apartmentNumber = value;
			}
		}
		public string Category
		{
			get => category;
			set
			{
				category = value;
				OnPropertyChanged("Category");

			}
		}
		public string AddressString { get; set; } 
		public Accommodation Accommodation { get; set; }
		public string AddOrUpdateButton { get; set; }

		public AddressPageCommand AddressPageCommand { get; set; }
		public ConfirmAddOrUpdateAccommodationCommand AddOrUpdateAccommodation { get; set; }
		public CancelAccommodationCommand CancelAccommodation { get; set; }

		public AccommodationPageViewModel(AgentViewModel agentViewModel)
		{
			CancelAccommodation = new CancelAccommodationCommand(this);
			AddOrUpdateAccommodation = new ConfirmAddOrUpdateAccommodationCommand(this);
			AddressPageCommand = new AddressPageCommand(this);
			AgentViewModel = agentViewModel;
			Accommodation = AgentViewModel.LoggedUser.AgentOfAccommodation;
			Types = (Enum.GetValues(typeof(AccommodationType))).OfType<AccommodationType>().ToList();

			if (Accommodation.Id != 0)
			{
				Name = Accommodation.Name;
				Description = Accommodation.Description;
				Type = Accommodation.AccommodationType;
				Category = Accommodation.Category;
				Country = Accommodation.Address.Country;
				City = Accommodation.Address.City;
				Street = Accommodation.Address.Street;
				Number = Accommodation.Address.Number;
				ApartmentNumber = Accommodation.Address.ApartmentNumber;
				AddressString = Country + ", " + City + ", " + Street + " " + Number;
				if (ApartmentNumber != null && ApartmentNumber != "")
				{
					AddressString += "/" + ApartmentNumber;
				}
				AddOrUpdateButton = "Update";
			}
			else
			{
				Accommodation.Address = new Address();
				AddOrUpdateButton = "Add";
			}


		}
	}
}
