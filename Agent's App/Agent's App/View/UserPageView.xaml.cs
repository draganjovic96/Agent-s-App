﻿using Agent_s_App.ViewModel;
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

namespace Agent_s_App.View
{
	/// <summary>
	/// Interaction logic for UserPageView.xaml
	/// </summary>
	public partial class UserPageView : UserControl
	{
		public UserPageView(AgentViewModel agentViewModel)
		{
			InitializeComponent();
			DataContext = new UserViewModel(agentViewModel);
		}
	}
}
