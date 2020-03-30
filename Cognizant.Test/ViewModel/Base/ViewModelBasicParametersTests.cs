using FC.Weidekalender.AppServices.Contracts;
using FC.Weidekalender.Core.ViewModels.Base;
using FC.Weidekalender.DataService.Contracts;
using Moq;
using MvvmCross.Logging;
using System;
using Xamarin.Forms;

namespace FC.Weidekalender.Test.ViewModel.Base
{
    public class ViewModelBasicParametersTests
    {
        public Mock<INavigationService> NavigationService { get; }
        public Mock<IMvxLog> LogProvider { get; }
        public Mock<IAuthInfoService> AuthInfoService { get; }
        public Mock<IFirebaseAnalytics> FirebaseAnalyticsService { get; }

        public MockSequence Sequence { get; set; }

        public Mock<IWeidekalenderContext> WeidecalendarContext { get; }
        public Mock<IDialogService> DialogService { get; }
        public Mock<IMessageService> MessageService { get; }
        public Mock<IAuthenticationService> AuthenticationService { get; }
        public Mock<ISecureStorageService> SecureStorageService { get; }

        public ViewModelBasicParametersTests()
        {
            this.NavigationService = new Mock<INavigationService>();
            this.WeidecalendarContext = new Mock<IWeidekalenderContext>();
            this.LogProvider = new Mock<IMvxLog>();
            this.DialogService = new Mock<IDialogService>();
            this.AuthInfoService = new Mock<IAuthInfoService>();
            this.FirebaseAnalyticsService = new Mock<IFirebaseAnalytics>();
            this.MessageService = new Mock<IMessageService>();
            this.AuthenticationService = new Mock<IAuthenticationService>();
            this.SecureStorageService = new Mock<ISecureStorageService>();

            var mockMessagingCenter = new Mock<IMessagingCenter>();
            mockMessagingCenter.Setup(mmc => mmc.Send(It.IsAny<MvxBaseViewModel>(), It.IsAny<string>(), It.IsAny<string>()));
            mockMessagingCenter.Setup(mmc => mmc.Subscribe(It.IsAny<MvxBaseViewModel>(), It.IsAny<string>(), It.IsAny<Action<MvxBaseViewModel, string>>(), null));

            this.Sequence = new MockSequence();

            this.MessageService.Setup(m => m.MessagingCenter).Returns(mockMessagingCenter.Object);

            //SetUp to get a valid token
            this.AuthInfoService.InSequence(this.Sequence).Setup(s => s.TokenIsValid()).ReturnsAsync(true);

            this.Parameters = new BaseViewModel(
                this.NavigationService.Object,
                this.LogProvider.Object,
                this.WeidecalendarContext.Object,
                this.DialogService.Object,
                this.AuthInfoService.Object,
                this.FirebaseAnalyticsService.Object,
                this.MessageService.Object,
                this.AuthenticationService.Object,
                this.SecureStorageService.Object);
        }

        /// <summary>
        /// Property to set up IViewModelBasicParameters property in all ViewModel Constructor
        /// </summary>
        public IBaseViewModel Parameters { get; private set; }
    }
}
