using Prism.Commands;
using Prism.Mvvm;
using Sast.AbstractSTree.Interfaces;
using Sast.AbstractSTree.Managers;
using Sast.AbstractSTree.Models.Nodes;
using Sast.Viewer.Interfaces;
using System.Collections.ObjectModel;
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

		public ObservableCollection<ITreeNode> AstRootList
		{
			get;
			set;
		} = new ObservableCollection<ITreeNode>();

		#endregion

		#region Private methdos

		private void Calculator()
		{
			ParserManager.Instance.FolderParse(@"D:\workspace\Targets");

			foreach (var pair in ParserManager.Instance.AstTreeMap)
			{
				AstRootList.Add(pair.Value);
			}
		}

		#endregion
	}
}
