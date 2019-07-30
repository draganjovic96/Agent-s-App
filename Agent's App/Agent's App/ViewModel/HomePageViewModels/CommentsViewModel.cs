using Agent_s_App.Core.Model;
using Agent_s_App.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ViewModel.HomePageViewModels
{
	public class CommentsViewModel : ViewModelBase
	{
		public Accommodation Accommodation { get; set; }
		public List<CommentRate> CommentRates { get; set; }
		public CommentRateService CommentRateService = new CommentRateService();

		public CommentsViewModel(Accommodation accommodation)
		{
			Accommodation = accommodation;
			CommentRates = CommentRateService.GetCommentRates(Accommodation);
			foreach (CommentRate commentRate in CommentRates)
			{
				commentRate.RateImage = "/View/Resources/stars_rating_0.png";
				if (commentRate.Ocena >= 1 && commentRate.Ocena <= 5)
				{
					commentRate.RateImage = "/View/Resources/stars_rating_" + commentRate.Ocena + ".png";
				}
			}
		}
	}
}
