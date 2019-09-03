using Agent_s_App.UserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class GetUserRequestDTO
	{
		public getUsersRequest GetUsersRequest { get; set; }

		public GetUserRequestDTO(string username)
		{
			GetUsersRequest = new getUsersRequest()
			{
				username = username
			};
		}
	}
}
