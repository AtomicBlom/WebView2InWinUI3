using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;

namespace WebView2InWinUI3;

#if DISABLE_XAML_GENERATED_MAIN
public static class Program
{
	[DllImport("Microsoft.ui.xaml.dll")]
	private static extern void XamlCheckProcessRequirements();
	
	[STAThread]
	//static void Main(string[] args) //Works
	static async Task Main(string[] args) //Doesn't Work
	{
		Debug.WriteLine(Thread.CurrentThread.GetApartmentState());
		XamlCheckProcessRequirements();

		WinRT.ComWrappersSupport.InitializeComWrappers();
			
		Application.Start((p) =>
		{
			var context = new DispatcherQueueSynchronizationContext(DispatcherQueue.GetForCurrentThread());
			SynchronizationContext.SetSynchronizationContext(context);
			new App();
		});
	}
}
#endif