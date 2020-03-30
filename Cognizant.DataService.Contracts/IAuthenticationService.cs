using System.Threading;
using System.Threading.Tasks;
using Cognizant.DataService.Entities;

namespace Cognizant.DataService.Contracts
{
    public interface IAuthenticationService
    {
        bool UserIsAllowedToUseTheApp(TokenEntity token, CancellationToken? cancellationToken = default);

        Task<bool> UserShouldLoginAgain();
    }
}
