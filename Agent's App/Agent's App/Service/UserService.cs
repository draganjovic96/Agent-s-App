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
			if (username.Equals("") || password.Equals(""))
			{ return null; }
			else
			{ return unitOfWork.Users.Get(1230); }
		}
	}
}
