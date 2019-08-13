using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class LoginRequestDTO
	{
		public UserServiceReference.loginRequest LoginRequest { get; set; }	

		public LoginRequestDTO(string Username, string Password)
		{
			LoginRequest = new UserServiceReference.loginRequest();

			LoginRequest.loginDTO = new UserServiceReference.LoginDTO()
			{
				username = Username,
				password = Password,
				role = UserRole.AGENT.ToString()
			};
		}
	}
}
