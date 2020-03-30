using Cognizant.Common.Constants;
using Cognizant.UI.Model.Enums;
using MvvmCross.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cognizant.Core.ViewModels.Base
{
    public class TabbedViewModel : MvxBaseViewModel
    {
        private bool loaded;

        public TabbedViewModel(IBaseViewModel parameters) : base(parameters)
        {
            this.loaded = false;
        }

        public override async void ViewAppearing()
        {
            base.ViewAppearing();
            await ShowInitialViewModels();
        }

        private async Task ShowInitialViewModels()
        {
            // avoid reload tabs if they are already loaded
            if (this.loaded)
            {
                return;
            }

            var tasks = new List<Task>();

            tasks.Add(this.BaseViewModel.NavigationService.MvxNavigationService.Navigate<HomeViewModel>());
            tasks.Add(this.BaseViewModel.NavigationService.MvxNavigationService.Navigate<CalendarViewModel>());
            tasks.Add(this.BaseViewModel.NavigationService.MvxNavigationService.Navigate<ProfileViewModel>());

            await Task.WhenAll(tasks);

            this.loaded = true;
        }
    }
}
