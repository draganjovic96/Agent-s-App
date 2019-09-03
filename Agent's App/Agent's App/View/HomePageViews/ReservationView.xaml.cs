using Agent_s_App.Core.Model;
using Agent_s_App.ViewModel.HomePageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agent_s_App.View.HomePageViews
{
	/// <summary>
	/// Interaction logic for ReservationView.xaml
	/// </summary>
	public partial class ReservationView : UserControl
	{
		public ReservationView(Reservation reservation, ReservationsViewModel reservationsViewModel)
		{
			InitializeComponent();
			DataContext = new ReservationViewModel(reservation, reservationsViewModel);
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}
