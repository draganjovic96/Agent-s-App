using Agent_s_App.PeriodPriceServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class GetPeriodPricesRequestDTO
	{
		public getPeriodPricesRequest GetPeriodPricesRequest { get; set; }

		public GetPeriodPricesRequestDTO(long unitId)
		{
			GetPeriodPricesRequest = new getPeriodPricesRequest()
			{
				accommodationUnitId = unitId
			};
		}
	}
}
