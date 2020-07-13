using Sast.Viewer.Interfaces;
using System.Windows;

namespace Sast.Viewer.Views
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainView : Window
	{
		#region Constructors

		public MainView()
		{
			InitializeComponent();
		}

		#endregion

		#region Event handlers

		private void mainView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (e.NewValue is IWindowHandler viewModel)
			{
				// 윈도우 닫기 이벤트 핸들러 바인딩.
				viewModel.OnCloseEvent += (sender, result) =>
				{
					Close();
				};

				viewModel.OpenWindowEvent += (sender, windowName) =>
				{
					var window = App.Bootstrapper.CreateContainer<Window>(windowName);
					if (window == null)
					{
						return null;
					}

					window.Owner = this;

					return window.ShowDialog();
				};
			}
		}

		#endregion
	}
}
