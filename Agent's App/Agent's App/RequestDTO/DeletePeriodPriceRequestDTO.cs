using Agent_s_App.PeriodPriceServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.RequestDTO
{
	public class DeletePeriodPriceRequestDTO
	{
		public removePeriodPriceRequest RemovePeriodPriceRequest { get; set; }

		public DeletePeriodPriceRequestDTO(long PeriodPriceId)
		{
			RemovePeriodPriceRequest = new removePeriodPriceRequest()
			{
				periodPriceId = PeriodPriceId
			};
		}
	}
}
