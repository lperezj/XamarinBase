using MvvmCross.Navigation;

namespace Cognizant.AppServices.Contracts
{
    public interface INavigationService
    {
        IMvxNavigationService MvxNavigationService { get; }
    }
}
