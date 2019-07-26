using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Core.Model
{
	public class CommentRate
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None), ForeignKey("Reservation")]
		public long Id { get; set; }

		public bool ApprovedComment { get; set; }

		public string ContentOfComment { get; set; }

		public DateTime CommentDateTime { get; set; }

		public virtual Reservation Reservation { get; set; }

		public int Ocena { get; set; }

		public string RateImage { get; set; }
	}
}
