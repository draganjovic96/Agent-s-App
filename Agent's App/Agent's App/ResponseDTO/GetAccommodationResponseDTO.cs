using Agent_s_App.AccommodationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ResponseDTO
{
	public class GetAccommodationResponseDTO
	{
		public Core.Model.Accommodation Accommodation { get; set; }

		public GetAccommodationResponseDTO(getAccommodationByUserResponse getAccommodationByUserResponse)
		{
			Accommodation = new Core.Model.Accommodation()
			{
				Id = getAccommodationByUserResponse.accommodation.Id,
				Description = getAccommodationByUserResponse.accommodation.Description,
				Name = getAccommodationByUserResponse.accommodation.Name,
				Category = getAccommodationByUserResponse.accommodation.Category,
				AccommodationType = (Core.Model.AccommodationType) Enum.Parse(typeof(Core.Model.AccommodationType), getAccommodationByUserResponse.accommodation.AccommodationType.ToString(), true),
				Address = new Core.Model.Address()
				{
					Id = getAccommodationByUserResponse.accommodation.Address.Id,
					Country = getAccommodationByUserResponse.accommodation.Address.Country,
					City = getAccommodationByUserResponse.accommodation.Address.City,
					Street = getAccommodationByUserResponse.accommodation.Address.Street,
					Number = getAccommodationByUserResponse.accommodation.Address.Number,
					ApartmentNumber = getAccommodationByUserResponse.accommodation.Address.Apartment_number,
					Longitude = getAccommodationByUserResponse.accommodation.Address.Longitude,
					Latitude = getAccommodationByUserResponse.accommodation.Address.Latitude,
					PostalCode = getAccommodationByUserResponse.accommodation.Address.Postal_code
				}
			};
		}
	}
}
