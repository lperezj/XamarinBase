using Cognizant.AppServices.Contracts;
using System.Threading.Tasks;
using Cognizant.UI.Model.Enums;

namespace Cognizant.Core.ViewModels.Base
{
    public interface IBaseViewModel
    {
        INavigationService NavigationService { get; }

        IContext Context { get; }

        //IAuthInfoService AuthInfoService { get; }

        //IAuthenticationService AuthenticationService { get; }

        //ISecureStorageService SecureStorageService { get; }

        //IMvxLog Log { get; }

        IDialogService DialogService { get; }

        //IFirebaseAnalytics FirebaseAnalyticsService { get; }

        IMessageService MessageService { get; }
    }
}
