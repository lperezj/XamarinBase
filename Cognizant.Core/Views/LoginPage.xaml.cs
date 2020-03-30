using System;
using Cognizant.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;

namespace Cognizant.Core.Views
{
    [MvxContentPagePresentation(WrapInNavigationPage = false, NoHistory = true)]
    public partial class LoginPage : MvxContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public void OnEyeButtonPressed(object sender, EventArgs args)
        {
            this.passwordEntry.IsPassword = !this.passwordEntry.IsPassword;
        }
    }
}
