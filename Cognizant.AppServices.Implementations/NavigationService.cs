using MvvmCross.Navigation;
using Cognizant.AppServices.Contracts;

namespace Cognizant.AppServices.Implementations
{
    public class NavigationService : INavigationService
    {
        public IMvxNavigationService MvxNavigationService { get; private set; }

        public NavigationService(IMvxNavigationService navigationService)
        {
            this.MvxNavigationService = navigationService;
        }
    }
}
