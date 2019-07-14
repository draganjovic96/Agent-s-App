using Agent_s_App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Agent_s_App.ViewModel
{
	public class MainViewModel : ViewModelBase
	{
		public UserControl ActivePage { get; set; }

		public MainViewModel()
		{
			ActivePage = new LogInView("Hidden", this);
		}
	}
}
