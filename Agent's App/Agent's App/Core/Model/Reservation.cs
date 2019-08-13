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
		public Reservation()
		{
			Messages = new HashSet<Message>();
		}
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long Id { get; set; }

		[Required]
		public DateTime FromDate { get; set; }

		[Required]
		public DateTime ToDate { get; set; }

		public bool Confirmed { get; set; }

		public bool AgentConfirmed { get; set; }

		public virtual CommentRate CommentRate { get; set; }

		[Required]
		public virtual AccommodationUnit AccommodationUnit { get; set; }

		public virtual ICollection<Message> Messages { get; set; }

		[Required]
		public virtual User Guest { get; set; }
	}
}
