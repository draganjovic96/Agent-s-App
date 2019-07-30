using Agent_s_App.Core.Model;
using Agent_s_App.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Service
{
	public class CommentRateService
	{
		private UnitOfWork unitOfWork = new UnitOfWork(MainWindow.context);

		public List<CommentRate> GetCommentRates(Accommodation accommodation)
		{
			return unitOfWork.CommentRates.Find(c => c.Reservation.AccommodationUnit.Accommodation.Id == accommodation.Id).ToList();
		}
	}
}
