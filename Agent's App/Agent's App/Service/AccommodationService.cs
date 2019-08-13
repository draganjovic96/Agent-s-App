using Agent_s_App.AccommodationServiceReference;
using Agent_s_App.Core.Model;
using Agent_s_App.Persistance;
using Agent_s_App.Persistance.Repository;
using Agent_s_App.RequestDTO;
using Agent_s_App.ResponseDTO;
using Agent_s_App.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Service
{
	public class AccommodationService
	{
		private readonly UnitOfWork unitOfWork = new UnitOfWork(MainWindow.context);

		private AccommodationPortClient accommodationPortClient = new AccommodationPortClient();

		private MojuserPortClient mojuserPortClient = new MojuserPortClient();

		public Accommodation GetAccommodationByUsername(string username)
		{
			try
			{
				GetAccommodationRequestDTO getAccommodationRequestDTO = new GetAccommodationRequestDTO(username);
				GetAccommodationResponseDTO getAccommodationResponseDTO = new GetAccommodationResponseDTO(accommodationPortClient.getAccommodationByUser(getAccommodationRequestDTO.getAccommodationByUserRequest));
				Core.Model.Accommodation accommodation = getAccommodationResponseDTO.Accommodation;

				Accommodation accommodationDB = unitOfWork.Accommodations.SingleOrDefault(a => a.Id == accommodation.Id);

				if (accommodationDB != null)
				{
					accommodationDB = accommodation;
					accommodationDB.AccommodationType = accommodation.AccommodationType;
					accommodationDB.Name = accommodation.Name;
					accommodationDB.Description = accommodation.Description;
					accommodationDB.Category = accommodation.Category;
					if (unitOfWork.Addresses.SingleOrDefault(a => a.Id == accommodation.Address.Id) == null)
					{
						unitOfWork.Addresses.Add(accommodation.Address);
						unitOfWork.Complete();
					}
					accommodationDB = unitOfWork.Accommodations.SingleOrDefault(a => a.Id == accommodation.Id);
					accommodationDB.Address = unitOfWork.Addresses.SingleOrDefault(a => a.Id == accommodation.Address.Id);
					unitOfWork.Complete();
				}
				else
				{
					User user = unitOfWork.Users.Find(x => x.Username == username).First();

					user.AgentOfAccommodation = accommodation;
					accommodation.Agents.Add(user);

					unitOfWork.Accommodations.Add(accommodation);
					unitOfWork.Complete();
				}
				
				return accommodation;
			}
			catch
			{
				return null;
			}
		}

		public void AddAccommodation(Accommodation accommodation, User user)
		{
			AddAccommodationRequestDTO addAccommodationRequestDTO = new AddAccommodationRequestDTO(accommodation);
			AddAccommodationResponseDTO addAccommodationResponseDTO = new AddAccommodationResponseDTO(accommodationPortClient.addAccommodation(addAccommodationRequestDTO.AddAccommodationRequest));
			Accommodation accommodationResponse = addAccommodationResponseDTO.Accommodation;

			UserServiceReference.addAccommodationToUserRequest addAccommodationToUserRequest = new addAccommodationToUserRequest()
			{
				AccommodationId = accommodationResponse.Id,
				UserId = user.Id
			};

			unitOfWork.Accommodations.Add(accommodationResponse);

			mojuserPortClient.addAccommodationToUser(addAccommodationToUserRequest);

			User userDB = unitOfWork.Users.Find(u => u.Id == user.Id).First();
			userDB.AgentOfAccommodation = accommodationResponse;

			unitOfWork.Complete();				
		}

		public void UpdateAccommodation(Accommodation accommodation)
		{
			UpdateAccommodationRequestDTO updateAccommodationRequestDTO = new UpdateAccommodationRequestDTO(accommodation);
			accommodationPortClient.updateAccommodation(updateAccommodationRequestDTO.UpdateAccommodatioRequest);
		}
	}
}
