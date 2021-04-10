using AppKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;
using Foundation;

namespace armyplanner.macOS
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        NSWindow window;
        /// <summary>
        /// 
        /// </summary>
        public override NSWindow MainWindow
        {
            get { return window; }
        }

        /// <summary>
        /// 
        /// </summary>
        public AppDelegate()
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

            var rect = new CoreGraphics.CGRect(200, 1000, 1024, 768);
            window = new NSWindow(rect, style, NSBackingStore.Buffered, false);
            window.Title = "Xamarin.Forms on Mac!"; // choose your own Title here
            window.TitleVisibility = NSWindowTitleVisibility.Hidden;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        public override void DidFinishLaunching(NSNotification notification)
        {
            Forms.Init();

            Startup.Init();

            App xamarinApp = new App(Startup.ServiceProvider);
            LoadApplication(xamarinApp);

            base.DidFinishLaunching(notification);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notification"></param>
        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
