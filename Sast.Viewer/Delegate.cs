using System.Windows;

namespace Sast.Viewer
{
	/// <summary>
	/// 윈도우 닫기 이벤트 핸들러.
	/// </summary>
	/// <param name="sender">발송자.</param>
	/// <param name="result">윈도우 닫기 결과.</param>
	public delegate void CloseEventHandler(object sender, bool? result);

	/// <summary>
	/// 메세지박스 출력 이벤트 핸들러.
	/// </summary>
	/// <param name="message">메세지.</param>
	/// <param name="type">메세지박스 타입.</param>
	/// <returns>메세지박스 결과.</returns>
	public delegate MessageBoxResult MessageEventHandler(string message, MessageBoxButton type);

	/// <summary>
	/// 자식 윈도우 출력 이벤트 핸들러.
	/// </summary>
	/// <param name="sender">발송자.</param>
	/// <param name="windowName">자식 윈도우 이름(부트스트래퍼)</param>
	/// <returns>윈도우 결과.</returns>
	public delegate bool? OpenWindowEventHandler(object sender, string windowName);
}
