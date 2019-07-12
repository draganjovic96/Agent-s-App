using Agent_s_App.Core;
using Agent_s_App.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Persistance.Repository
{

	public class UnitOfWork : IUnitOfWork
	{
		private readonly AgentsAppContext _context;

		public UnitOfWork(AgentsAppContext context)
		{
			_context = context;
			Users = new UserRepository(_context);
			Addresses = new AddressRepository(_context);
		}

		public IUserRepository Users { get; private set; }

		public IAddressRepository Addresses { get; private set; }

		public int Complete()
		{
			return _context.SaveChanges();
		}

		public void Dispose()
		{
			_context.Dispose();
		}
	}
}
