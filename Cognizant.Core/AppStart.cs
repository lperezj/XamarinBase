using System;
using System.Threading.Tasks;
using Cognizant.AppServices.Contracts;
using Cognizant.Common.Constants;
using Cognizant.Core.ViewModels;
using Cognizant.Core.ViewModels.Base;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Cognizant.Core
{
    public class AppStart : MvxAppStart
    {
        private readonly ISecureStorageService secureStorageService;
        private readonly IAppInfo appInfo;
        private readonly IContext context;

        public AppStart(IMvxApplication application, IMvxNavigationService navigationService, ISecureStorageService secureStorageService, IContext context, IAppInfo appInfo) : base(application, navigationService)
        {
            this.context = context;
            this.secureStorageService = secureStorageService;
            this.appInfo = appInfo;
        }

        protected override async Task NavigateToFirstViewModel(object hint = null)
        {
            try
            {
                if (Xamarin.Essentials.VersionTracking.IsFirstLaunchEver)
                {
                    //await secureStorageService.RemoveAll();
                }

                /* TOKEN VALIDATION */
                await SetAppStart();
            }
            catch (Exception ex)
            {
                NavigationService.Navigate<LoginViewModel>().GetAwaiter().GetResult();
            }
        }

        private async Task SetAppStart()
        {
            await NavigationService.Navigate<LoginViewModel>();
        }
    }
}