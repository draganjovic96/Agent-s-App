using Agent_s_App.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Core
{
	public interface IUnitOfWork : IDisposable
	{
		IUserRepository Users { get; }
		IAddressRepository Addresses { get; }
		int Complete();
	}
}
