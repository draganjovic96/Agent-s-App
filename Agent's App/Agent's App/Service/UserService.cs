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
	public class UserService
	{
		private readonly UnitOfWork unitOfWork = new UnitOfWork(MainWindow.context);

		private MojuserPortClient MojUserPortClient = new MojuserPortClient();

		public User LogIn(string username, string password)
		{
			LoginRequestDTO loginRequestDTO = new LoginRequestDTO(username, password);
			try
			{
				LoginResponseDTO loginResponseDTO = new LoginResponseDTO(MojUserPortClient.login(loginRequestDTO.LoginRequest));
				User response = loginResponseDTO.User;

				User userDB = unitOfWork.Users.SingleOrDefault(u => u.Id == response.Id);

				if (userDB != null)
				{
					userDB = response;
					unitOfWork.Complete();
				}
				else
				{
					unitOfWork.Users.Add(response);
					unitOfWork.Complete();
				}
					
				return response;
			}
			catch
			{
				return null;
			}			
		}

		public void UpdateUser(User user)
		{
			UpdateUserRequestDTO updateUserRequestDTO = new UpdateUserRequestDTO(user);
			updateUserResponse respone = MojUserPortClient.updateUser(updateUserRequestDTO.UpdateUserRequest);
			LogIn(user.Username, user.Password);
		}
	}
}
