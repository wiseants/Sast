using Prism.Commands;
using Prism.Mvvm;
using Sast.AbstractSTree.Interfaces;
using Sast.AbstractSTree.Managers;
using Sast.AbstractSTree.Models.Nodes;
using Sast.Viewer.Interfaces;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Input;

namespace Sast.Viewer.ViewModels
{
	public class MainViewModel : BindableBase, IWindowHandler
	{
		#region Fields

		public event OpenWindowEventHandler OpenWindowEvent;
		public event CloseEventHandler OnCloseEvent;

		private string _folderPath;
		private string _message;

		#endregion

		#region Constructors

		public MainViewModel()
		{
			FolderPath = Settings.Default.TargetFolderPath;

			ConvertCommand = new DelegateCommand(Convert);
			OpenFolderDialogCommand = new DelegateCommand(OpenFolderDialog);
		}

		#endregion

		#region Properties

		public ICommand ConvertCommand
		{
			get;
			set;
		}

		public ICommand OpenFolderDialogCommand
		{
			get;
			set;
		}

		public string FolderPath
		{
			get { return _folderPath; }
			set 
			{ 
				SetProperty(ref _folderPath, value);

				Settings.Default.TargetFolderPath = FolderPath;
				Settings.Default.Save();
			}
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

		
		private void OpenFolderDialog()
		{
			using var dialog = new FolderBrowserDialog();
			DialogResult result = dialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				FolderPath = dialog.SelectedPath;
			}
		}

		private void Convert()
		{
			ParserManager.Instance.FolderParse(FolderPath);

			foreach (var pair in ParserManager.Instance.AstTreeMap)
			{
				AstRootList.Add(pair.Value);
			}
		}

		#endregion
	}
}
