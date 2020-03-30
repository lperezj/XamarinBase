using System;
using System.Threading.Tasks;
using Cognizant.AppServices.Contracts;
using Cognizant.Common;
using Cognizant.Common.Constants;
using Cognizant.DataService.Entities;

namespace Cognizant.AppServices.Implementations
{
    public class AuthInfoService : IAuthInfoService
    {
        private readonly ISecureStorageService secureStorage;

        public AuthInfoService(ISecureStorageService secureStorageService)
        {
            this.secureStorage = secureStorageService;
        }

        public DateTime GetTokenExpirationDate(string accessToken)
        {
            return TokenUtilities.GetExpirationDate(accessToken);
        }

        public async Task<TokenEntity> GetToken()
        {
            var token = await this.secureStorage.Get<string>(StorageConstants.ACCESS_TOKEN);
            if (string.IsNullOrEmpty(token))
            {
                return null;
            }

            var tokenDeserialized = TokenUtilities.DeserializeToken(token);
            return tokenDeserialized;
        }

        public async Task<bool> TokenIsValid()
        {
            var token = await this.secureStorage.Get<string>(StorageConstants.ACCESS_TOKEN);
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }
            var expirationString = await this.secureStorage.Get<string>(StorageConstants.EXPIRATION_DATE);

            return TokenUtilities.TokenIsValid(token, expirationString);
        }

        public bool TokenHasPermissions(/* Change the parameters to validate */)
        {
            return false;
        }

        public TokenEntity DeserializeToken(string token)
        {
            return TokenUtilities.DeserializeToken(token);
        }
    }
}
