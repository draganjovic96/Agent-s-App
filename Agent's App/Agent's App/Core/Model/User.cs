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
	public enum UserRole
	{
		REGISTERED_USER,
		AGENT,
		ADMINISTRATOR
	}

	public class User
	{
		#region fields
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public long Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string LastName { get; set; }

		public string Email { get; set; }

		public string Username { get; set; }

		[Required]
		public string Password { get; set; }

		public bool Enabled { get; set; }

		public bool Deleted { get; set; }

		[Required]
		public UserRole Role { get; set; }

		public Address Address { get; set; }

		public long BusinessRegistrationNumber { get; set; }

		public bool Blocked;

		#endregion

		#region properties
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

		//public string Username
		//{
		//	get
		//	{
		//		return this.username;
		//	}
		//	set
		//	{
		//		this.username = value;
		//		this.RaisePropertyChanged("Username");
		//	}
		//}

		//public string Name
		//{
		//	get
		//	{
		//		return this.name;
		//	}
		//	set
		//	{
		//		this.name = value;
		//		this.RaisePropertyChanged("Name");
		//	}
		//}

		//public string LastName
		//{
		//	get
		//	{
		//		return this.lastname;
		//	}
		//	set
		//	{
		//		this.lastname = value;
		//		this.RaisePropertyChanged("LastName");
		//	}
		//}

		//public string Email
		//{
		//	get
		//	{
		//		return this.email;
		//	}
		//	set
		//	{
		//		this.email = value;
		//	}
		//}

		//public string Password
		//{
		//	get
		//	{
		//		return this.password;
		//	}
		//	set
		//	{
		//		this.password = value;
		//		this.RaisePropertyChanged("Password");
		//	}
		//}

		//public long BussinesRegistrationNumber
		//{
		//	get
		//	{
		//		return this.businessRegistrationNumber;
		//	}
		//	set
		//	{
		//		this.businessRegistrationNumber = value;
		//	}
		//}

		//public bool Blocked
		//{
		//	get
		//	{
		//		return this.blocked;
		//	}
		//	set
		//	{
		//		this.blocked = value;
		//	}
		//}

		//public bool Enabled
		//{
		//	get
		//	{
		//		return this.enabled;
		//	}
		//	set
		//	{
		//		this.enabled = value;
		//	}
		//}

		//public bool Deleted
		//{
		//	get
		//	{
		//		return this.deleted;
		//	}
		//	set
		//	{
		//		this.deleted = value;
		//	}
		//}

		//public UserRole Role
		//{
		//	get
		//	{
		//		return this.role;
		//	}
		//	set
		//	{
		//		this.role = value;
		//		RaisePropertyChanged("Role");
		//	}
		//}

		//public Address Address
		//{
		//	get
		//	{
		//		return this.address;
		//	}
		//	set
		//	{
		//		this.address = value;
		//	}
		//}
		#endregion

	}
}

