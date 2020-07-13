using Prism.Commands;
using Prism.Mvvm;
using Sast.Viewer.Interfaces;
using System.Windows.Input;

namespace Sast.Viewer.ViewModels
{
	public class MainViewModel : BindableBase, IWindowHandler
	{
		#region Fields

		public event OpenWindowEventHandler OpenWindowEvent;
		public event CloseEventHandler OnCloseEvent;

		private string _command;
		private string _message;

		#endregion

		#region Constructors

		public MainViewModel()
		{
			CalculatorCommand = new DelegateCommand(Calculator);
		}

		#endregion

		#region Properties

		public ICommand CalculatorCommand
		{
			get;
			set;
		}

		public string Command
		{
			get { return _command; }
			set { SetProperty(ref _command, value); }
		}

		public string Message
		{
			get { return _message; }
			set { SetProperty(ref _message, value); }
		}

		#endregion

		#region Private methdos

		private void Calculator()
		{
			OnCloseEvent(this, true);
		}

		#endregion
	}
}
