using Agent_s_App.Core.Model;
using Agent_s_App.Persistance.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Service
{
	public class AddressService
	{
		public UnitOfWork unitOfWork = new UnitOfWork(MainWindow.context);

		public void AddAddress(Address address)
		{
			unitOfWork.Addresses.Add(address);
			unitOfWork.Complete();
		}
	}
}
