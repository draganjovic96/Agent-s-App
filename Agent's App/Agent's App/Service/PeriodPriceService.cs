using Agent_s_App.Core.Model;
using Agent_s_App.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Service
{
    public class PeriodPriceService
    {
		private readonly UnitOfWork unitOfWork = new UnitOfWork(MainWindow.context);

		public List<PeriodPrice> GetPeriodPrices(long accommodationUnitId)
		{
			return unitOfWork.PeriodPrices.Find(x => x.AccommodationUnit.Id == accommodationUnitId).ToList();
		}
    }
}
