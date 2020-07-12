using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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

		#endregion

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

			ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver((viewType) =>
			{
				var viewName = viewType.FullName;
				var viewModelName = String.Format(CultureInfo.InvariantCulture, "{0}Model", viewName);
				return Type.GetType(viewModelName);
			});
		}

		#endregion

	}
}
