using System.Threading;
using System.Threading.Tasks;

namespace Cognizant.DataService.Contracts
{
    public interface IApiService
    {
        Task<TResult> GetData<TResult>(string parameters, CancellationToken? cancellationToken = null) where TResult: class;

        Task<TResult> PostData<TResult, TType>(string endpoint, TType parameters, CancellationToken? cancellationToken = null) where TResult : class;
    }
}
