using Agent_s_App.Core.Model;
using Agent_s_App.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ResponseDTO
{
	public class LoginResponseDTO
	{
		public User User { get; set; }

		public LoginResponseDTO(loginResponse loginResponse)
		{
			User = new User()
			{
				Username = loginResponse.user.Username,
				Name = loginResponse.user.Name,
				LastName = loginResponse.user.Lastname,
				Email = loginResponse.user.Email,
				Id = loginResponse.user.Id,
				Password = loginResponse.user.Password,
				Role = (UserRole)Enum.Parse(typeof(UserRole), loginResponse.user.Role, true),
				BusinessRegistrationNumber = loginResponse.user.Bussines_registration_number,
				Enabled = loginResponse.user.Enabled,
				Deleted = loginResponse.user.Deleted,
				Blocked = loginResponse.user.Blocked,
				Address = new Core.Model.Address()
				{
					Id = loginResponse.user.Address.Id,
					Country =  loginResponse.user.Address.Country,
					City = loginResponse.user.Address.City,
					Street = loginResponse.user.Address.Street,
					Number = loginResponse.user.Address.Number,
					ApartmentNumber = loginResponse.user.Address.Apartment_number,
					Longitude = loginResponse.user.Address.Longitude,
					Latitude = loginResponse.user.Address.Latitude,
					PostalCode = loginResponse.user.Address.Postal_code
				}
			};
		}
	}
}
