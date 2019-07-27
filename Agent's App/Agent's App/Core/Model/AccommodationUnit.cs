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
		public AccommodationUnit()
		{
			PeriodPrices = new HashSet<PeriodPrice>();
			Reservations = new HashSet<Reservation>();
		}
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long Id { get; set; }

		public int Floor { get; set; }

		[Required]
		public string Number { get; set; }

		public int NumberOfBeds { get; set; }

		public double DefaultPrice { get; set; }

		public bool Deleted;

		public virtual ICollection<PeriodPrice> PeriodPrices { get; set; }

		public virtual ICollection<Reservation> Reservations { get; set; }

		[Required]
		public virtual AccommodationUnitType AccommodationUnitType { get; set; }

		[Required]
		public virtual Accommodation Accommodation { get; set; }

	}
}
