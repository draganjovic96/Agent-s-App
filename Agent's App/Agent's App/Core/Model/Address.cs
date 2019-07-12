using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Core.Model
{
	public class Address
	{
		#region fields

		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long Id { get; set; }

		[Required]
		public string Country { get; set; }

		[Required]
		public string City { get; set; }

		public int PostalCode { get; set; }

		[Required]
		public string Street { get; set; }

		[Required]
		public string Number { get; set; }

		public string ApartmentNumber { get; set; }

		public double Longitude { get; set; }

		public double Latitude { get; set; }

		#endregion

	}
}
