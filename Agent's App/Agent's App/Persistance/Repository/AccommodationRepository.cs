using Agent_s_App.Core.Model;
using Agent_s_App.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Persistance.Repository
{
	public class AccommodationRepository : Repository<Accommodation>, IAccommodationRepository
	{
		public AccommodationRepository(AgentsAppContext context) : base(context)
		{
		}

		public AgentsAppContext AgentsAppContext
		{
			get { return Context as AgentsAppContext; }
		}
	}
}
