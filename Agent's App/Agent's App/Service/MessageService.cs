using Agent_s_App.Core.Model;
using Agent_s_App.MessageServiceReference;
using Agent_s_App.Persistance.Repository;
using Agent_s_App.ResponseDTO;
using System.Collections.Generic;
using System.Linq;
using Agent_s_App.RequestDTO;

namespace Agent_s_App.Service
{
	public class MessageService
	{
		private readonly UnitOfWork unitOfWork = new UnitOfWork(MainWindow.context);

		private MessagePortClient messagePortClient = new MessagePortClient();

		private UserServiceReference.MojuserPortClient userPortClient = new UserServiceReference.MojuserPortClient();

		private AddressService addressService = new AddressService();

		public List<Message> getMessagesByReservation(long reservationId)
		{
			getMessagesByReservationRequest getMessagesByReservationRequest = new getMessagesByReservationRequest() { id = reservationId };
			GetMessagesByReservationResponseDTO responseDTO = new GetMessagesByReservationResponseDTO(messagePortClient.getMessagesByReservation(getMessagesByReservationRequest));
			foreach (Message message in responseDTO.Messages)
			{
				List<User> users = new List<User>();
				if (message.Receiver != null)
				{
					users.Add(message.Receiver);
				}
				users.Add(message.Sender);

				//modificate sender and reciever in local DB
				foreach (User user in users)
				{
					GetUserRequestDTO getUserRequestDTO = new GetUserRequestDTO(user.Username);
					GetUserResponseDTO getUserResponseDTO = new GetUserResponseDTO(userPortClient.getUsers(getUserRequestDTO.GetUsersRequest), user.Username);
					User newUser = getUserResponseDTO.User;
					addressService.updateAddress(newUser.Address);


					User userDB = unitOfWork.Users.SingleOrDefault(u => u.Id == user.Id);
					if (userDB != null)
					{
						//update user in local DB
						//userDB = newUser;
						System.Console.WriteLine("postoji vec user!");
						userDB.Name = newUser.Name;
						userDB.LastName = newUser.LastName;
						userDB.Password = newUser.Password;
						userDB.Blocked = newUser.Blocked;
						userDB.Deleted = newUser.Deleted;
						userDB.Address = unitOfWork.Addresses.SingleOrDefault(a => a.Id == newUser.Address.Id);
					}
					else
					{
						unitOfWork.Users.Add(newUser);
					}
					unitOfWork.Complete();
					
				}

				Message messageDB = unitOfWork.Messages.SingleOrDefault(m => m.Id == message.Id);
				if (messageDB != null)
				{
					if (message.Receiver != null)
						messageDB.Receiver = unitOfWork.Users.SingleOrDefault(u => u.Id == message.Receiver.Id);
					messageDB.Seen = message.Seen;
				}
				else
				{
					message.Sender = unitOfWork.Users.SingleOrDefault(u => u.Id == message.Sender.Id);
					if (message.Receiver != null)
						message.Receiver = unitOfWork.Users.SingleOrDefault(u => u.Id == message.Receiver.Id);
					message.Reservation = unitOfWork.Reservations.Get(message.Reservation.Id);
					unitOfWork.Messages.Add(message);
				}
				unitOfWork.Complete();

			}
			return unitOfWork.Messages.Find(m => m.Reservation.Id == reservationId).ToList();
		}

		public void SetMessagesSeen(long reservationId, string username)
		{
			Reservation reservation = unitOfWork.Reservations.Get(reservationId);
			SetMessagesSeenRequestDTO setMessagesSeen = new SetMessagesSeenRequestDTO(reservation.Messages.OrderByDescending(m => m.DatumVreme).First().Id, username);
			try
			{
				messagePortClient.respond(setMessagesSeen.RespondRequest);
			}
			catch
			{

			}
		}

		public void SendMessage(long reservationId, Message message)
		{
			Reservation reservation = unitOfWork.Reservations.Get(reservationId);
			List<Message> messages = unitOfWork.Messages.Find(m => m.Reservation.Id == reservationId && m.Sender.Role != UserRole.AGENT).ToList();
			SendMessageRequestDTO sendMessageRequestDTO = new SendMessageRequestDTO(reservationId, messages.OrderByDescending(m => m.DatumVreme).First().Id, message);
			try
			{
				messagePortClient.respond(sendMessageRequestDTO.RespondRequest);
			}
			catch
			{

			}
			getMessagesByReservation(reservationId);
		}
	}
}
