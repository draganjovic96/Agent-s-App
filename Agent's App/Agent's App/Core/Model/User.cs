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

		[Required]
		public Address Address { get; set; }

		public long BusinessRegistrationNumber { get; set; }

		public bool Blocked;

		public Accommodation AgentOfAccommodation { get; set; }

		#endregion

	}
}

