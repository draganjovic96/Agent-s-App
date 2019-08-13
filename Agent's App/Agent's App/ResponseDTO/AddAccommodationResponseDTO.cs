using Agent_s_App.AccommodationServiceReference;
using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ResponseDTO
{
	public class AddAccommodationResponseDTO
	{
		public Accommodation Accommodation { get; set; }

		public AddAccommodationResponseDTO(addAccommodationResponse addAccommodationResponse)
		{
			Accommodation = new Accommodation()
			{
				Id = addAccommodationResponse.accommodation.Id,
				Name = addAccommodationResponse.accommodation.Name,
				Description = addAccommodationResponse.accommodation.Description,
				Category = addAccommodationResponse.accommodation.Category,
				AccommodationType = (AccommodationType)Enum.Parse(typeof(AccommodationType), addAccommodationResponse.accommodation.AccommodationType.ToString(), true),
				Address = new Core.Model.Address()
				{
					Id = addAccommodationResponse.accommodation.Address.Id,
					Country = addAccommodationResponse.accommodation.Address.Country,
					City = addAccommodationResponse.accommodation.Address.City,
					Street = addAccommodationResponse.accommodation.Address.Street,
					Number = addAccommodationResponse.accommodation.Address.Number,
					ApartmentNumber = addAccommodationResponse.accommodation.Address.Apartment_number,
					Longitude = addAccommodationResponse.accommodation.Address.Longitude,
					Latitude = addAccommodationResponse.accommodation.Address.Latitude,
					PostalCode = addAccommodationResponse.accommodation.Address.Postal_code

				}
			};
		}
	}
}
