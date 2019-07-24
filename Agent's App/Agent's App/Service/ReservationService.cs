using Agent_s_App.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Service
{
	public class ReservationService
	{
		private readonly UnitOfWork unitOfWork = new UnitOfWork(MainWindow.context);
	}
}
