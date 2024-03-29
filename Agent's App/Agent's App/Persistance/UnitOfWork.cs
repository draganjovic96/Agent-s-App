﻿using Agent_s_App.Core;
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
			Accommodations = new AccommodationRepository(_context);
			AccommodationUnits = new AccommodationUnitRepository(_context);
			AccommodationUnitTypes = new AccommodationUnitTypeRepository(_context);
			AccommodationServices = new AccommodationServiceRepository(_context);
			CommentRates = new CommentRateRepository(_context);
			PeriodPrices = new PeriodPriceRepository(_context);
			Messages = new MessageRepository(_context);
			Reservations = new ReservationRepository(_context);
		}

		public IUserRepository Users { get; private set; }
		public IAddressRepository Addresses { get; private set; }
		public IAccommodationRepository Accommodations { get; private set;}
		public IAccommodationUnitRepository AccommodationUnits { get; private set; }
		public IAccommodationUnitTypeRepository AccommodationUnitTypes { get; private set; }
		public IAccommodationServiceRepository AccommodationServices { get; private set; }
		public ICommentRateRepository CommentRates { get; private set; }
		public IPeriodPriceRepository PeriodPrices { get; private set; }
		public IMessageRepository Messages { get; private set; }
		public IReservationRepository Reservations { get; private set; }

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
