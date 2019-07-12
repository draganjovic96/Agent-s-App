using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Core.Model
{
	public class AccommodationUnit
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long Id { get; set; }

		public int Floor { get; set; }

		[Required]
		public string Number { get; set; }

		public int NumberOfBeds { get; set; }

		public double DefaultPrice { get; set; }

		public bool Deleted;

		public List<PeriodPrice> PeriodPrices { get; set; }

		public List<Reservation> Reservations { get; set; }

		[Required]
		public AccommodationUnitType AccommodationUnitType { get; set; }

		[Required]
		public Accommodation Accommodation { get; set; }

	}
}
