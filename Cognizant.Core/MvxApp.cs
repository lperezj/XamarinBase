using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MonkeyCache.FileStore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Xamarin.Forms;
using Cognizant.Core.ViewModels.Base;
using Cognizant.AppServices.Contracts;
using Cognizant.AppServices.Implementations;
using Cognizant.DataService.Contracts;
using Cognizant.DataService.Implementations;
using Cognizant.Common.Constants;

namespace Cognizant.Core
{
    public class MvxApp : MvxApplication
    {
        private const string APP_SETTINGS_FILE = "Cognizant.Core.appsettings.json";

        public override void Initialize()
        {
            base.Initialize();
            //Barrel.ApplicationId = AppConstants.APP_ID;

            RegisterAppServices();
            Mvx.IoCProvider.RegisterType<IBaseViewModel, BaseViewModel>();

            RegisterDataServices();

            RegisterCustomAppStart<AppStart>();
        }

        private static void RegisterAppServices()
        {
            var mvxNavigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            Mvx.IoCProvider.RegisterSingleton(typeof(INavigationService), new NavigationService(mvxNavigationService));

            Mvx.IoCProvider.RegisterSingleton(typeof(IAppInfo), new AppInfo());
            Mvx.IoCProvider.RegisterSingleton(typeof(ISecureStorageService), new SecureStorageService());
            Mvx.IoCProvider.RegisterSingleton(typeof(IDialogService), new DialogService());
            Mvx.IoCProvider.RegisterSingleton(typeof(IContext),new Context());
            Mvx.IoCProvider.RegisterSingleton(typeof(IMessageService), new MessageService());

            //Mvx.IoCProvider.RegisterSingleton(typeof(IFirebaseAnalytics), DependencyService.Get<IFirebaseAnalytics>());

            //Mvx.IoCProvider.RegisterType<IAuthInfoService, AuthInfoService>();

            // Register the services needed to get Secret Constants from appsettings.json file

            //Mvx.IoCProvider.RegisterType<IConfigurationRoot>(() => BuildConfiguration());
            //Mvx.IoCProvider.RegisterType<IAppConfiguration, AppConfiguration>();
        }

        private static void RegisterDataServices()
        {
            Mvx.IoCProvider.RegisterType<IApiService, ApiService>();
            //Mvx.IoCProvider.RegisterType<IAuthenticationService, AuthenticationService>();
        }

        /// <summary>
        /// Create an instance for the IConfigurationRoot.
        /// It should be created here because <see cref="APP_SETTINGS_FILE"/>.json file should be in this assembly
        /// and .Build() is not working in an independent class inside other assembly
        /// </summary>
        /// <returns>An instance of configuration</returns>
        private static IConfigurationRoot BuildConfiguration()
        {
            var embeddedResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(APP_SETTINGS_FILE);

            var configuration = new ConfigurationBuilder()
                .AddJsonStream(embeddedResourceStream)
                .Build();
            return configuration;
        }
    }
}
