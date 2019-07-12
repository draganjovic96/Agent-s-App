using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Core.Model
{
	public class Reservation
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long Id { get; set; }

		[Required]
		public DateTime FromDate { get; set; }

		[Required]
		public DateTime ToDate { get; set; }

		public bool Confirmed { get; set; }

		public bool AgentConfirmed { get; set; }

		public CommentRate CommentRate { get; set; }

		[Required]
		public AccommodationUnit AccommodationUnit { get; set; }

		public List<Message> Messages { get; set; }

		public User Guest { get; set; }
	}
}
