using Agent_s_App.AccommodationServiceReference;
using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class AddAccommodationRequestDTO
	{
		public addAccommodationRequest AddAccommodationRequest { get; set; }


		public AddAccommodationRequestDTO(Accommodation Accommodation)
		{
			AddAccommodationRequest = new addAccommodationRequest()
			{
				accommodation = new accommodation()
				{
					Name = Accommodation.Name,
					Description = Accommodation.Description,
					Category = Accommodation.Category,
					AccommodationType = (accommodationType) Enum.Parse(typeof(accommodationType), Accommodation.AccommodationType.ToString(), true),
					Address = new AccommodationServiceReference.Address()
					{
						Country = Accommodation.Address.Country,
						City = Accommodation.Address.City,
						Street = Accommodation.Address.Street,
						Number = Accommodation.Address.Number,
						Apartment_number = Accommodation.Address.ApartmentNumber,
						Longitude = Accommodation.Address.Longitude,
						Latitude = Accommodation.Address.Latitude,
						Postal_code = Accommodation.Address.PostalCode
					}
				}
			};

		}
	}
}
