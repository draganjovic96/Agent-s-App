﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Core.Model
{
	public class Message
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long Id { get; set; }

		public string MessageContent { get; set; }

		public bool Seen { get; set; }

		public virtual User Sender { get; set; }

		public virtual User Receiver { get; set; }

		public DateTime DatumVreme { get; set; }

		public bool Deleted { get; set; }

		public virtual Reservation Reservation { get; set; }

		public virtual Accommodation Accommodation { get; set; }
	}
}
