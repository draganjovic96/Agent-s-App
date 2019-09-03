using Agent_s_App.Core.Model;
using Agent_s_App.PeriodPriceServiceReference;
using Agent_s_App.Persistance.Repository;
using Agent_s_App.RequestDTO;
using Agent_s_App.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agent_s_App.Service
{
	public class PeriodPriceService
	{
		private readonly UnitOfWork unitOfWork = new UnitOfWork(MainWindow.context);

		private PeriodPricePortClient periodPricePortClient = new PeriodPricePortClient();

		public List<PeriodPrice> GetPeriodPrices(long accommodationUnitId)
		{
			GetPeriodPricesRequestDTO getPeriodPricesRequestDTO = new GetPeriodPricesRequestDTO(accommodationUnitId);
			try
			{
				GetPeriodPricesResponseDTO getPeriodPricesResponseDTO = new GetPeriodPricesResponseDTO(periodPricePortClient.getPeriodPrices(getPeriodPricesRequestDTO.GetPeriodPricesRequest));
				List<PeriodPrice> periodPrices = getPeriodPricesResponseDTO.PeriodPrices;
				if (periodPrices.Count > 0)
				{
					foreach (PeriodPrice periodPrice in periodPrices)
					{
						PeriodPrice periodPriceDB = unitOfWork.PeriodPrices.SingleOrDefault(pp => pp.Id == periodPrice.Id);
						if (periodPriceDB != null)
						{
							periodPriceDB.Price = periodPrice.Price;
							periodPriceDB.FromDate = periodPrice.FromDate;
							periodPriceDB.ToDate = periodPrice.ToDate;
							periodPriceDB.Deleted = false;
						}
						else
						{
							periodPrice.AccommodationUnit = unitOfWork.AccommodationUnits.SingleOrDefault(au => au.Id == accommodationUnitId);
							unitOfWork.PeriodPrices.Add(periodPrice);
						}
						unitOfWork.Complete();
					}

					//set deleted period prices in localDB
					List<PeriodPrice> periodPricesDB = unitOfWork.PeriodPrices.Find(p => p.AccommodationUnit.Id == accommodationUnitId).ToList();
					foreach (PeriodPrice periodPriceDB in periodPricesDB)
					{
						int flag = 0;
						foreach (PeriodPrice periodPrice in periodPrices)
						{
							if (periodPrice.Id == periodPriceDB.Id)
								flag += 1;
						}

						if (flag == 0)
						{
							periodPriceDB.Deleted = true;
							unitOfWork.Complete();
						}
					}
				}
			}
			catch { }
			return unitOfWork.PeriodPrices.Find( p => p.AccommodationUnit.Id == accommodationUnitId && !p.Deleted).ToList();
		}

		public void AddPeriodPrice(PeriodPrice periodPrice, long accommodationUnitId)
		{
			AddPeriodPriceRequestDTO addPeriodPriceRequestDTO = new AddPeriodPriceRequestDTO(periodPrice, accommodationUnitId);
			periodPricePortClient.addPeriodPrice(addPeriodPriceRequestDTO.AddPeriodPriceRequest);
		}

		public bool UpdatePeriodPrice(PeriodPrice periodPrice)
		{
			try
			{
				UpdatePeriodPriceRequestDTO updatePeriodPriceDTO = new UpdatePeriodPriceRequestDTO(periodPrice);
				periodPricePortClient.updatePeriodPrice(updatePeriodPriceDTO.UpdatePeriodPriceRequest);
				return true;
			}
			catch
			{
				return false;
			}
		}
		public bool DeletePeriodPrice(long periodPriceId)
		{
			try
			{
				DeletePeriodPriceRequestDTO deletePeriodPriceDTO = new DeletePeriodPriceRequestDTO(periodPriceId);
				periodPricePortClient.removePeriodPrice(deletePeriodPriceDTO.RemovePeriodPriceRequest);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
