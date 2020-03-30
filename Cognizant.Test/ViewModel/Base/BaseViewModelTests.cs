using System;
using System.Reflection;
using Acr.UserDialogs;
using Microsoft.Extensions.Configuration;
using Moq;

namespace FC.Weidekalender.Test.ViewModel.Base
{
    public class BaseViewModelTests : IDisposable
    {
        public const string APP_SETTINGS_FILE = "FC.Weidekalender.Test.ViewModel.Base.appsettings.json";

        public BaseViewModelTests()
        {
            this.BasicParameters = new ViewModelBasicParametersTests();
        }

        public ViewModelBasicParametersTests BasicParameters { get; set; }

        public virtual void Dispose()
        {
            this.BasicParameters.AuthInfoService.Verify(v => v.TokenIsValid(), Times.Once, "TokenIsValid Method not called");
        }

        public static IProgressDialog GetLoadingTaskSetup(AppServices.Contracts.IDialogService s)
        {
            return s.LoadingWithCancellation(It.IsAny<Action>(), true, MaskType.Black);
        }

        public static IConfigurationRoot BuildConfiguration()
        {
            var assembly = Assembly.GetExecutingAssembly();

            var embeddedResourceStream = assembly.GetManifestResourceStream(APP_SETTINGS_FILE);

            var configuration = new ConfigurationBuilder()
                .AddJsonStream(embeddedResourceStream)
                .Build();

            return configuration;
        }
    }
}
