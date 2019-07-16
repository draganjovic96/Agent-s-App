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
	public class AccommodationService
	{
		private readonly UnitOfWork unitOfWork = new UnitOfWork(new AgentsAppContext());

		public Accommodation GetAccommodationByUsername(string username)
		{
			User user = unitOfWork.Users.Find(x => x.Username == username).First();
			return user.AgentOfAccommodation;
		}
	}
}
