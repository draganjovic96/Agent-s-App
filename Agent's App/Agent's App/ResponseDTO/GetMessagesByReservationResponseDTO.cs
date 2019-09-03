using Agent_s_App.Core.Model;
using Agent_s_App.MessageServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ResponseDTO
{
	public class GetMessagesByReservationResponseDTO
	{
		public List<Message> Messages { get; set; }

		public GetMessagesByReservationResponseDTO(message[] messagesResponse)
		{
			Messages = new List<Message>();
			if (messagesResponse.Length > 0)
			{
				foreach (message messageResponse in messagesResponse)
				{
					Message message = new Message()
					{
						//dodati jos datum i vrijeme
						Id = messageResponse.id,
						MessageContent = messageResponse.messageContent,
						Seen = messageResponse.seen,
						DatumVreme = new DateTime(2019, 10, 10, 11, 43, 56),
						Sender = new User()
						{
							Id = messageResponse.sender.Id,
							Username = messageResponse.sender.Username
						},
						Reservation = new Reservation()
						{
							Id = messageResponse.reservation.id
						}
					};
					if (messageResponse.reciever != null)
					{
						message.Receiver = new User()
						{
							Id = messageResponse.reciever.Id,
							Username = messageResponse.reciever.Username
						};

					}

					Messages.Add(message);
				}
			}
			
		}
	}
}
