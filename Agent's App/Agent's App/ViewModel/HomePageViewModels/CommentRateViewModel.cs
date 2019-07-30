using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ViewModel.HomePageViewModels
{
	public class CommentRateViewModel : ViewModelBase
	{
		public string Comment { get; set; }
		public string RatingImage { get; set; }
		public string Time { get; set; }

		public CommentRateViewModel(CommentRate commentRate)
		{
			RatingImage = "/View/Resources/stars_rating_0.png";

			if (commentRate != null)
			{
				Comment = commentRate.ContentOfComment;
				Time = commentRate.CommentDateTime.ToLongDateString() + " " + commentRate.CommentDateTime.ToLongTimeString();
				if (commentRate.Ocena >= 1 && commentRate.Ocena <= 5)
				{
					RatingImage = "/View/Resources/stars_rating_" + commentRate.Ocena + ".png";
				}
			}
		}
	}
}
