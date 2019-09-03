using Agent_s_App.Core.Model;
using Agent_s_App.MessageServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class SendMessageRequestDTO
	{
		public respondRequest RespondRequest { get; set; }

		public SendMessageRequestDTO(long reservationId, long messageId, Message message)
		{
			RespondRequest = new respondRequest()
			{
				respondId = messageId,
				message = new messageToSend()
				{
					senderUsername = message.Sender.Username,
					messageContent = message.MessageContent,
					reservationId = reservationId
				}
			};
		}
	}
}
