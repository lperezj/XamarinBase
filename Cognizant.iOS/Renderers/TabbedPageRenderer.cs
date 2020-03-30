using Cognizant.iOS.Renderers;
using Xamarin.Forms.Platform.iOS;

[assembly: Xamarin.Forms.ExportRenderer(typeof(Xamarin.Forms.TabbedPage), typeof(TabbedPageRenderer))]
namespace Cognizant.iOS.Renderers
{
    public class TabbedPageRenderer : TabbedRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            
            //TabBar.TintColor = UIColor.Red;
            //TabBar.BarTintColor = UIColor.Brown;
            //TabBar.BackgroundColor = UIColor.White;
            //TabBar.UnselectedItemTintColor = UIColor.SystemBlueColor;
        }
    }
}
