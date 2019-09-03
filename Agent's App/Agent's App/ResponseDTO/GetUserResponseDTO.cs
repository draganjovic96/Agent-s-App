using Agent_s_App.Core.Model;
using Agent_s_App.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ResponseDTO
{
	public class GetUserResponseDTO
	{
		public User User { get; set; }

		public GetUserResponseDTO(user[] users, string username)
		{
			foreach (user user in users)
			{
				if (user.Username.Equals(username))
				{
					User = new User()
					{
						Username = user.Username,
						Name = user.Name,
						LastName = user.Lastname,
						Email = user.Email,
						Id = user.Id,
						Password = user.Password,
						Role = (UserRole)Enum.Parse(typeof(UserRole), user.Role, true),
						BusinessRegistrationNumber = user.Bussines_registration_number,
						Enabled = user.Enabled,
						Deleted = user.Deleted,
						Blocked = user.Blocked,
						Address = new Core.Model.Address()
						{
							Id = user.Address.Id,
							Country = user.Address.Country,
							City = user.Address.City,
							Street = user.Address.Street,
							Number = user.Address.Number,
							ApartmentNumber = user.Address.Apartment_number,
							Longitude = user.Address.Longitude,
							Latitude = user.Address.Latitude,
							PostalCode = user.Address.Postal_code
						}
					};
				}
			}
		}
	}
}
