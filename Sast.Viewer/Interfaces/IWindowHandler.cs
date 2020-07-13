namespace Sast.Viewer.Interfaces
{
	/// <summary>
	/// 기본 윈도우 뷰 핸들링 인터페이스.
	/// </summary>
	public interface IWindowHandler
	{
		/// <summary>
		/// 자식 윈도우 열기 이벤트.
		/// </summary>
		event OpenWindowEventHandler OpenWindowEvent;

		/// <summary>
		/// 윈도우 닫기 이벤트.
		/// </summary>
		event CloseEventHandler OnCloseEvent;
	}
}
