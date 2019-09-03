using Agent_s_App.Core.Model;
using Agent_s_App.PeriodPriceServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.ResponseDTO
{
	public class GetPeriodPricesResponseDTO
	{
		public List<PeriodPrice> PeriodPrices { get; set; }

		public GetPeriodPricesResponseDTO(getPeriodPricesResponse getPeriodPricesResponse)
		{
			PeriodPrices = new List<PeriodPrice>();
			foreach (periodPrice periodPriceResponse in getPeriodPricesResponse.periodPrices)
			{
				PeriodPrice periodPrice = new PeriodPrice()
				{
					Id = periodPriceResponse.Id,
					Price = periodPriceResponse.Price,
					FromDate = periodPriceResponse.FromDate,
					ToDate = periodPriceResponse.ToDate
				};
				PeriodPrices.Add(periodPrice);
			}
		}
	}
}
