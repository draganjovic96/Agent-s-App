using Agent_s_App.Core.Model;
using Agent_s_App.PeriodPriceServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class UpdatePeriodPriceRequestDTO
	{
		public updatePeriodPriceRequest UpdatePeriodPriceRequest { get; set; }

		public UpdatePeriodPriceRequestDTO(PeriodPrice PeriodPrice)
		{
			UpdatePeriodPriceRequest = new updatePeriodPriceRequest()
			{
				periodPrice = new periodPrice()
				{
					Id = PeriodPrice.Id,
					Price = PeriodPrice.Price,
					FromDate = PeriodPrice.FromDate.Date,
					ToDate = PeriodPrice.ToDate.Date,
					AccommodationUnit = new accommodationUnit()
					{
						Id = PeriodPrice.AccommodationUnit.Id
					}
				}
			};
		}
	}
}
