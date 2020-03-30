using System;
using System.Threading.Tasks;
using Cognizant.DataService.Entities;

namespace Cognizant.AppServices.Contracts
{
    public interface IAuthInfoService
    {
        /// <summary>
        /// A token is valid when it exists (!null and !empty)
        /// and the expiration date is grater than now.
        /// </summary>
        /// <returns>If the token is valid or not</returns>
        Task<bool> TokenIsValid();

        /// <summary>
        /// Returns the expiration date of a given token
        /// </summary>
        /// <param name="accessToken">The token to decode</param>
        /// <returns>The expiration date</returns>
        DateTime GetTokenExpirationDate(string accessToken);

        /// <summary>
        /// A token has permissions when the roles collection is not empty
        /// and his items are valid to enter in the app.
        /// </summary>
        /// <returns></returns>
        bool TokenHasPermissions();

        /// <summary>
        /// Return the token
        /// </summary>
        /// <returns></returns>
        Task<TokenEntity> GetToken();

        /// <summary>
        /// Given a string with JWT token returns all information
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Token´s information</returns>
        TokenEntity DeserializeToken(string token);
     
    }
}
