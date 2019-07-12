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
		public virtual DbSet<Accommodation> Accommodations { get; set; }
		public virtual DbSet<AccommodationUnit> AccommodationUnits { get; set; }
		public virtual DbSet<AccommodationUnitType> AccommodationUnitTypes { get; set; }
		public virtual DbSet<AccommodationService> AccommodationServices { get; set; }
		public virtual DbSet<CommentRate> CommentRates { get; set; }
		public virtual DbSet<PeriodPrice> PeriodPrices { get; set; }
		public virtual DbSet<Message> Messages { get; set; }
		public virtual DbSet<Reservation> Reservations { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
		}
	}
}
