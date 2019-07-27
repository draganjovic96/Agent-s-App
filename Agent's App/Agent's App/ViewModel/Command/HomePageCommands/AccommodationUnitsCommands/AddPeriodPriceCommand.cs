using Agent_s_App.ViewModel.HomePageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command.HomePageCommands.AccommodationUnitsCommands
{
	public class AddPeriodPriceCommand : ICommand
	{
		public PeriodPricesViewModel PeriodPricesViewModel { get; set; }

		public AddPeriodPriceCommand(PeriodPricesViewModel periodPricesViewModel)
		{
			PeriodPricesViewModel = periodPricesViewModel;
		}
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			PeriodPricesViewModel.setPeriodPricePage(null);		
		}
	}
}
