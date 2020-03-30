using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms;

namespace Cognizant.Core.Views.Base
{
    [MvxTabbedPagePresentation(TabbedPosition.Root)]
    public partial class TabbedPage : MvvmCross.Forms.Views.MvxTabbedPage
    {
        public TabbedPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
