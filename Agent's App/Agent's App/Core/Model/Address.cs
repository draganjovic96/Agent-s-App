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

		//#region properties
		//public long Id
		//{
		//	get
		//	{
		//		return this.id;
		//	}
		//	set
		//	{
		//		this.id = value;
		//		this.RaisePropertyChanged("Id");
		//	}
		//}

		//public string Country
		//{
		//	get
		//	{
		//		return this.country;
		//	}
		//	set
		//	{
		//		this.country = value;
		//		this.RaisePropertyChanged("Country");
		//	}
		//}

		//public string City
		//{
		//	get
		//	{
		//		return this.city;
		//	}
		//	set
		//	{
		//		this.city = value;
		//		this.RaisePropertyChanged("City");
		//	}
		//}

		//public string Street
		//{
		//	get
		//	{
		//		return this.street;
		//	}
		//	set
		//	{
		//		this.street = value;
		//		this.RaisePropertyChanged("Street");
		//	}
		//}

		//public string Number
		//{
		//	get
		//	{
		//		return this.number;
		//	}
		//	set
		//	{
		//		this.number = value;
		//		this.RaisePropertyChanged("Number");
		//	}
		//}

		//public string ApartmentNumber
		//{
		//	get
		//	{
		//		return this.apartmentNumber;
		//	}
		//	set
		//	{
		//		this.apartmentNumber = value;
		//		this.RaisePropertyChanged("ApartmentNumber");
		//	}
		//}

		//public int PostalCode
		//{
		//	get
		//	{
		//		return this.postalCode;
		//	}
		//	set
		//	{
		//		this.postalCode = value;
		//		this.RaisePropertyChanged("PostalCode");
		//	}
		//}

		//public double Longitude
		//{
		//	get
		//	{
		//		return this.longitude;
		//	}
		//	set
		//	{
		//		this.longitude = value;
		//		this.RaisePropertyChanged("Longitude");
		//	}
		//}

		//public double Latitude
		//{
		//	get
		//	{
		//		return this.latitude;
		//	}
		//	set
		//	{
		//		this.latitude = value;
		//		this.RaisePropertyChanged("Latitude");
		//	}
		//}

		//#endregion

	}
}
