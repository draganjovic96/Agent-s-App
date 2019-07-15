using Agent_s_App.Core.Model;
using Agent_s_App.Persistance;
using Agent_s_App.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Service
{
	public class UserService
	{
		private readonly UnitOfWork unitOfWork = new UnitOfWork(new AgentsAppContext());

		public User LogIn(string username, string password)
		{
			IEnumerable<User> response = unitOfWork.Users.Find(x => x.Username == username && x.Password == password);
			if (response.Count() != 0)
				return response.First();
			else
				return null;

		}
	}
}
