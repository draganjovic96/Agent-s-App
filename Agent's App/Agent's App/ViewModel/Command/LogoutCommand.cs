using Agent_s_App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Agent_s_App.ViewModel.Command
{
	public class LogoutCommand : ICommand
	{
		public AgentViewModel AgentViewModel { get; set; }

		public LogoutCommand(AgentViewModel agentViewModel)
		{
			AgentViewModel = agentViewModel;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			AgentViewModel.MainViewModel.ActivePage = new LogInView("Hidden", AgentViewModel.MainViewModel);
		}
	}
}
