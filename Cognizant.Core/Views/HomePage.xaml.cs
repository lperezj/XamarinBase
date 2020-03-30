using Cognizant.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;

namespace Cognizant.Core.Views
{
    [MvxTabbedPagePresentation(NoHistory = true, Position = TabbedPosition.Tab)]
    public partial class HomePage : MvxContentPage
    {
        public HomePage()
        {
            Title = "Home";
            IconImageSource = "home.png";
            InitializeComponent();
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            if (this.DataContext is HomeViewModel vm)
            {
                vm.OnViewModelSet();
            }
        }
    }
}
