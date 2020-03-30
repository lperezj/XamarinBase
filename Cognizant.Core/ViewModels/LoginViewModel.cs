using System;
using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Cognizant.Core.ViewModels.Base;
using MvvmCross.Commands;

namespace Cognizant.Core.ViewModels
{
    public class LoginViewModel : MvxBaseViewModel
    {
        private string username;
        private string password;
        private bool isLoginEnabled;

        private CancellationTokenSource cancellationTokenSource;

        public LoginViewModel(IBaseViewModel parameters) : base(parameters)
        {
            this.LoginCommand = new MvxAsyncCommand(() => this.LoginCommandExecute());
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();
        }

        public bool IsLoginEnabled
        {
            get => isLoginEnabled;
            set
            {
                SetProperty(ref isLoginEnabled, value);
                this.LoginCommandCanExecute();
            }
        }

        public string Username
        {
            get => username;
            set
            {
                SetProperty(ref username, value);
                this.LoginCommandCanExecute();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                SetProperty(ref password, value);
                this.LoginCommandCanExecute();
            }
        }

        public MvxAsyncCommand LoginCommand { get; }

        private void LoginCommandCanExecute()
        {
            var isEnabled = true;

            if (this.Username == null || this.Username.Trim().Equals(string.Empty)) { isEnabled = false; }
            if (this.Password == null || this.Password.Trim().Equals(string.Empty)) { isEnabled = false; }

            this.IsLoginEnabled = isEnabled;
        }

        private async Task LoginCommandExecute()
        {
            try
            {
                using (this.BaseViewModel.DialogService.LoadingWithCancellation("Loading","Cancel"))
                {
                    await this.BaseViewModel.NavigationService.MvxNavigationService.Navigate<TabbedViewModel>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                await this.RaisePropertyChanged(nameof(this.IsLoginEnabled));

                //this.DisposeCancellationToken();
            }
        }

        private void LoginCommandCancelled()
        {
            this.cancellationTokenSource.Cancel();
            this.RaisePropertyChanged(nameof(this.IsLoginEnabled));
        }

        private void DisposeCancellationToken()
        {
            if (this.cancellationTokenSource != null)
            {
                this.cancellationTokenSource.Dispose();
                this.cancellationTokenSource = null;
            }
        }

        private void InitCancellationToken()
        {
            this.cancellationTokenSource = new CancellationTokenSource();
        }
    }
}