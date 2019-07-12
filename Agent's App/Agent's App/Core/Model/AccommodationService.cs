﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Core.Model
{
	public class AccommodationService
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long Id { get; set; }

		[Required]
		public string Name { get; set; }

		public string Description { get; set; }

		public bool Deleted { get; set; }

		public List<Accommodation> Accommodations { get; set; }
	}
}
