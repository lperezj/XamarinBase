using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using Cognizant.AppServices.Contracts;

namespace Cognizant.Core.ViewModels.Base
{
    public class BaseViewModel : IBaseViewModel, INotifyPropertyChanged
    {
        private bool isNotInternet;
        private bool showAlternativeMessageButton;

        public BaseViewModel(
            INavigationService navigationService,
            IContext context,
            IDialogService userDialog,
            IMessageService messageService,
            ISecureStorageService secureStorageService)
        {
            this.NavigationService = navigationService;
            this.Context = context;
            this.DialogService = userDialog;
            this.MessageService = messageService;

            if (DeviceInfo.Platform == DevicePlatform.Unknown)
                return;

            this.IsNotInternet = Connectivity.NetworkAccess != NetworkAccess.Internet;
            
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public INavigationService NavigationService { get; private set; }
        public IContext Context { get; private set; }
        public IDialogService DialogService { get; private set; }
        public IMessageService MessageService { get; private set; }

        public bool ShouldNavigateToLogin { get; set; }

        public bool IsNotInternet
        {
            get { return isNotInternet; }
            set { isNotInternet = value; NotifyPropertyChanged(); }
        }

        public bool ShowAlternativeMessageButton
        {
            get { return showAlternativeMessageButton; }
            set { showAlternativeMessageButton = value; NotifyPropertyChanged(); }
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            var access = e.NetworkAccess;
            this.IsNotInternet = access != NetworkAccess.Internet;
        }

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        protected void NotifyPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
