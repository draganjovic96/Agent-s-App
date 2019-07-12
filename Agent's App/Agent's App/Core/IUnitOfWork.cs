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
		IAccommodationRepository Accommodations { get; }
		IAccommodationUnitRepository AccommodationUnits { get; }
		IAccommodationUnitTypeRepository AccommodationUnitTypes { get; }
		IAccommodationServiceRepository AccommodationServices { get; }
		ICommentRateRepository CommentRates { get; }
		IPeriodPriceRepository PeriodPrices { get; }
		IMessageRepository Messages { get; }
		IReservationRepository Reservations { get; }
		int Complete();
	}
}
