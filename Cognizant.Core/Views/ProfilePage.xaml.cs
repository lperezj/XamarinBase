using Cognizant.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;

namespace Cognizant.Core.Views
{
    [MvxTabbedPagePresentation(WrapInNavigationPage = false)]
    public partial class ProfilePage : MvxContentPage
    {
        public ProfilePage()
        {
            Title = "Profile";
            IconImageSource = "profile.png";
            InitializeComponent();
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            if (this.DataContext is ProfileViewModel vm)
            {
                vm.OnViewModelSet();
            }
        }
    }
}
