using Cognizant.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;

namespace Cognizant.Core.Views
{
    [MvxTabbedPagePresentation(WrapInNavigationPage = false)]
    public partial class CalendarPage : MvxContentPage
    {
        public CalendarPage()
        {
            Title = "Calendar";
            IconImageSource = "calendar.png";
            InitializeComponent();
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            if (this.DataContext is CalendarViewModel vm)
            {
                vm.OnViewModelSet();
            }
        }
    }
}
