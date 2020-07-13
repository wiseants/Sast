using Prism.Mvvm;
using Sast.Viewer.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using Unity;

namespace Sast.Viewer
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		#region Fields

		//public static event ChangedRecipe ChangedRecipe;
		//public static readonly string RECIPE_RESOURCE_KEY = "Recipe";
		public static readonly string LOCATOR_RESOURCE_KEY = "Locator";

		private static Bootstrapper _bootstrapper = null;

		#endregion

		public static IUnityContainer Container
		{
			get => _bootstrapper?.Container;
		}

		#region Public methods

		public static Cores.ViewModelLocator Locator
		{
			get
			{
				return Current.Resources[LOCATOR_RESOURCE_KEY] as Cores.ViewModelLocator;
			}
		}

		#endregion

		#region Override methods

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			_bootstrapper = new Bootstrapper();

			ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
			{
				return Type.GetType(string.Format(CultureInfo.InvariantCulture, "{0}Model", viewType.FullName));
			});

			Current.Resources = new ResourceDictionary
			{
				{ LOCATOR_RESOURCE_KEY, Container.Resolve<Cores.ViewModelLocator>() }
			};

			MainView window = new MainView();
			window.Show();
		}

		#endregion

	}
}
