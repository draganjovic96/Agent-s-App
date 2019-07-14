using Agent_s_App.Core.Model;
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
		private UserControl activePage;

		public UserControl ActivePage
		{
			get => activePage;
			set
			{ activePage = value; OnPropertyChanged("ActivePage"); }
		}

		public MainViewModel()
		{
			ActivePage = new LogInView("Hidden", this);
		}

		public void SetActivePage(User user)
		{
			if (user != null)
			{ ActivePage = new UserControl1(); }
			else { ActivePage = new LogInView("Visible", this); }
		}
	}
}
