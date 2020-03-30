using System.Threading;
using System.Threading.Tasks;
using Cognizant.AppServices.Contracts;
using Cognizant.Common.Constants;
using Cognizant.DataService.Contracts;
using Cognizant.DataService.Entities;

namespace Cognizant.DataService.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthInfoService authInfoService;
        private readonly ISecureStorageService secureStorageService;

        public AuthenticationService(IAuthInfoService authInfoService, ISecureStorageService storageService, IContext context)
        {
            this.authInfoService = authInfoService;
            this.secureStorageService = storageService;
        }

        public bool UserIsAllowedToUseTheApp(TokenEntity token, CancellationToken? cancellationToken = null)
        {
            var userIsAllowedToAccess = this.authInfoService.TokenHasPermissions(); // digital;automaticDigital;analog

            return userIsAllowedToAccess;
        }

        public async Task<bool> UserShouldLoginAgain()
        {
            var tokenIsValid = await this.authInfoService.TokenIsValid();
            if (!tokenIsValid)
            {
                return true;
            }
            else
            {
                var tokenEntity = await this.secureStorageService.Get<TokenEntity>(StorageConstants.TOKEN_ENTITY);
                if (tokenEntity is null)
                {
                    return true;
                }
                var userIsAllowed = this.UserIsAllowedToUseTheApp(tokenEntity);

                return userIsAllowed ? false : true;
            }
        }
    }
}
