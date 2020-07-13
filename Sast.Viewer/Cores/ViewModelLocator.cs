using Prism.Mvvm;

namespace Sast.Viewer.Cores
{
	/// <summary>
	/// 뷰모델 로케이터.
	/// </summary>
	public class ViewModelLocator
	{
		#region Constructors

		public ViewModelLocator()
		{
		}

		#endregion

		#region Properties

		/// <summary>
		/// 메인 윈도우 뷰모델.
		/// </summary>
		public BindableBase MainViewModel
		{
			get
			{
				return Bootstrapper.Instance.CreateContainer<BindableBase>("main");
			}
		}

		#endregion
	}
}