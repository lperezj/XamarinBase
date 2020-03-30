
using System.Net.Http;
using Cognizant.AppServices.Contracts;
using Cognizant.DataService.Implementations;

namespace Cognizant.DataService.Implementations.Test
{
    public class TesteableApiService : ApiService
    {
        public TesteableApiService(HttpClient mockHttpclient, IAppConfiguration appConfiguration, IAppInfo appInfo) : base(appConfiguration, appInfo)
        {
            this.httpClient = mockHttpclient;
        }
    }
}
