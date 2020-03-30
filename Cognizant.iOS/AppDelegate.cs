using Cognizant.Core;
using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using UIKit;

namespace Cognizant.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxFormsApplicationDelegate<MvxFormsIosSetup<MvxApp, App>, MvxApp, App>
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            //Firebase.Core.App.Configure();
            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
