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
		private readonly UnitOfWork unitOfWork = new UnitOfWork(MainWindow.context);

		public void updateAddress(Address address)
		{
			Address addressDB = unitOfWork.Addresses.SingleOrDefault(a => a.Id == address.Id);
			if (addressDB != null)
			{
				addressDB.Country = address.Country;
				addressDB.City = address.City;
				addressDB.Street = address.Street;
				addressDB.Number = address.Number;
				addressDB.ApartmentNumber = address.ApartmentNumber;
				addressDB.Longitude = address.Longitude;
				addressDB.Latitude = address.Latitude;
				addressDB.PostalCode = address.PostalCode;
			}
			else
			{
				unitOfWork.Addresses.Add(address);
			}
			unitOfWork.Complete();
		}
	}
}
