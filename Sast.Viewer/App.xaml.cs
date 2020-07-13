using Sast.Viewer.Interfaces;
using System.Windows;
using Unity;

namespace Sast.Viewer
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		#region Fields

		public static readonly string LOCATOR_RESOURCE_KEY = "Locator";

		#endregion

		#region Properties

		public static Bootstrapper Bootstrapper
		{
			get;
		} = new Bootstrapper();

		#endregion

		#region Override methods

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			Current.Resources = new ResourceDictionary
			{
				{ LOCATOR_RESOURCE_KEY, Bootstrapper.Container.Resolve<Cores.ViewModelLocator>() }
			};

			Bootstrapper.Container.Resolve<Window>("Main").Show();
		}

		#endregion

	}
}
