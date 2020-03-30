using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;
using Xamarin.Forms;

namespace Cognizant.Android
{
    [Activity(
    Label = "Cognizant",
    MainLauncher = true,
    Icon = "@mipmap/icon",
    Theme = "@style/Theme.Splash",
    ConfigurationChanges = ConfigChanges.ScreenSize,
    ScreenOrientation = ScreenOrientation.Portrait,
    LaunchMode = LaunchMode.SingleTask)]
    public class MainActivity : MvxFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            //TabLayoutResource = Resource.Layout.Tabbar;
            //ToolbarResource = Resource.Layout.Toolbar;
            
            UserDialogs.Init(this);
            Forms.SetFlags("IndicatorView_Experimental");
            Xamarin.Essentials.Platform.Init(this, bundle);
            
            base.OnCreate(bundle);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }

}
