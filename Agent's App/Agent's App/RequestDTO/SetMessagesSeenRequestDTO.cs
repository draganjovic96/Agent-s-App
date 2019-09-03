using Agent_s_App.MessageServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class SetMessagesSeenRequestDTO
	{
		public respondRequest RespondRequest { get; set; }

		public SetMessagesSeenRequestDTO(long messageId, string username)
		{
			RespondRequest = new respondRequest()
			{
				respondId = messageId,
				message = new messageToSend()
				{
					senderUsername = username
				}
			};
		}
	}
}
