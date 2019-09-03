using Agent_s_App.Core.Model;
using Agent_s_App.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class UpdateUserRequestDTO
	{
		public updateUserRequest UpdateUserRequest { get; set; }

		public UpdateUserRequestDTO(User user)
		{
			UpdateUserRequest = new updateUserRequest()
			{
				user = new user()
				{
					Id = user.Id,
					Name = user.Name,
					Lastname = user.LastName,
					Bussines_registration_number = user.BusinessRegistrationNumber,
					Password = user.Password,
					Email = user.Email,
					Username = user.Username,
					Address = new UserServiceReference.Address()
					{
						Id = user.Address.Id,
						Country = user.Address.Country,
						City = user.Address.City,
						Street = user.Address.Street,
						Number = user.Address.Number,
						Apartment_number = user.Address.ApartmentNumber,
						Longitude = user.Address.Longitude,
						Latitude = user.Address.Latitude,
						Postal_code = user.Address.PostalCode
					}
				}
			};
		}
	}
}
