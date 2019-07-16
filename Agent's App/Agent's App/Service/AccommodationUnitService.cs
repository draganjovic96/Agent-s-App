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
	public class AccommodationUnitService
	{
		private readonly UnitOfWork unitOfWork = new UnitOfWork(new AgentsAppContext());
		public List<AccommodationUnit> GetAccommodationUnits(long accommodationId)
		{
			return unitOfWork.AccommodationUnits.Find(x => x.Accommodation.Id == accommodationId).ToList();
		}
	}
}
