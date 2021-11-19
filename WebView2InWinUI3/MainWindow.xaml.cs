using Microsoft.UI.Xaml;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WebView2InWinUI3
{
	/// <summary>
	/// An empty window that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainWindow : Window
	{
		public event Action XamlReady;

		public MainWindow()
		{
			this.InitializeComponent();
		}

		public async Task NavigateToFirstPage()
		{
			WebView.CoreWebView2Initialized += (_, args) =>
			{
				if (args.Exception != null)
					Debug.Assert(args.Exception == null, args.Exception?.Message);
			};
			await WebView.EnsureCoreWebView2Async();
			WebView.CoreWebView2.Navigate("http://www.google.com");
		}

		private void OnXamlReady(object sender, RoutedEventArgs e)
		{
			XamlReady?.Invoke();
		}
	}
	
}
