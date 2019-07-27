using Agent_s_App.Core.Model;
using Agent_s_App.ViewModel;
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
    /// Interaction logic for PeriodPrices.xaml
    /// </summary>
    public partial class PeriodPricesView : UserControl
    {
        public PeriodPricesView(HomePageViewModel homePageViewModel, AccommodationUnit unit)
        {
            InitializeComponent();
			DataContext = new PeriodPricesViewModel(homePageViewModel, unit);
        }
    }
}
