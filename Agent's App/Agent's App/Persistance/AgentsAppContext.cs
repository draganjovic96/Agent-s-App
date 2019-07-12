using Agent_s_App.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Persistance
{
	public class AgentsAppContext : DbContext
	{
		public AgentsAppContext()
			: base("name=AgentsAppContext")
		{
			this.Configuration.LazyLoadingEnabled = false;
		}

		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Address> Addresses { get; set; }

		//protected override void OnModelCreating(DbModelBuilder modelBuilder)
		//{
		//	modelBuilder.Configurations.Add(new CourseConfiguration());
		//}
	}
}
