using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Core.Model
{
	public enum AccommodationType
	{
		HOTEL,
		MOTEL,
		BED_AND_BREAKFAST
	}

	public class Accommodation
	{

		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long Id { get; set; }

		public List<AccommodationService> Services { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public string Name { get; set; }

		public List<AccommodationUnit> AccommodationUnits { get; set; }

		[Required]
		public List<User> Agents { get; set; }

		[Required]
		public string Category { get; set; }

		[Required]
		public Address Address { get; set; }

		[Required]
		public AccommodationType AccommodationType { get; set; }

	}

}
