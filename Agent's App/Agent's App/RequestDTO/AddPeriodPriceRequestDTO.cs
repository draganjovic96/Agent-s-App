using Agent_s_App.Core.Model;
using Agent_s_App.PeriodPriceServiceReference;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class AddPeriodPriceRequestDTO
	{
		public addPeriodPriceRequest AddPeriodPriceRequest { get; set; }

		public AddPeriodPriceRequestDTO(PeriodPrice PeriodPrice, long unitId)
		{
			AddPeriodPriceRequest = new addPeriodPriceRequest()
			{
				accommodationUnitId = unitId,
				periodPrice = new periodPrice()
				{
					Price = PeriodPrice.Price,
					FromDate = PeriodPrice.FromDate.Date,
					ToDate = PeriodPrice.ToDate.Date
				}
			};
		}
	}
}
