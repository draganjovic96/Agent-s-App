using Agent_s_App.Core.Model;
using Agent_s_App.ViewModel.Command.AccommodationPageCommands;
using Agent_s_App.ViewModel.Command.UserPageCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ViewModel
{
	public class UserViewModel : ViewModelBase
	{
		private string password;
		private string name;
		private string lastname;

		public string Username { get; set; }
		public string Email { get; set; }
		public string BusinessNumber { get; set; }
		public string Password
		{
			get => password;
			set
			{
				password = value;
				OnPropertyChanged("Password");
			}
		}
		public string Name
		{
			get => name;
			set
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}
		public string Lastname
		{
			get => lastname;
			set
			{
				lastname = value;
				OnPropertyChanged("Lastname");
			}
		}
		public string AddressString { get; set; }

		public AgentViewModel AgentViewModel { get; set; }
		public User User { get; set; }
		public AddressPageCommand AddressPageCommand { get; set; }
		public ConfirmUpdateUserCommand UpdateUser { get; set; }
		public CancelUserCommand CancelUser { get; set; }

		public UserViewModel(AgentViewModel agentViewModel)
		{
			AddressPageCommand = new AddressPageCommand(null, this);
			UpdateUser = new ConfirmUpdateUserCommand(this);
			CancelUser = new CancelUserCommand(this);

			AgentViewModel = agentViewModel;
			User = AgentViewModel.LoggedUser;
			Username = User.Username;
			Password = User.Password;
			Name = User.Name;
			Lastname = User.LastName;
			Email = User.Email;
			BusinessNumber = User.BusinessRegistrationNumber.ToString();
			AddressString = User.Address.Country + ", " + User.Address.City + ", " + User.Address.Street + " " + User.Address.Number;
			if (User.Address.ApartmentNumber != null && User.Address.ApartmentNumber != "")
			{
				AddressString += "/" + User.Address.ApartmentNumber;
			}
		}
	}
}
