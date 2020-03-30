using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using System.Text;
using System.Threading;
using Cognizant.DataService.Contracts;
using Cognizant.AppServices.Contracts;
using System.Net.Http;
using System.Net;
using System.Diagnostics;
using Cognizant.DataService.Common;

namespace Cognizant.DataService.Implementations
{
    public class ApiService : IApiService
    {
        private readonly IAppConfiguration configuration;
        private readonly IAppInfo appInfo;
        protected HttpClient httpClient;

        public ApiService(IAppConfiguration appConfiguration, IAppInfo appInfo)
        {
            /* We get the access token in each method, except for login.
             * We use this.GetAccessToken(); */
            this.configuration = appConfiguration;
            this.appInfo = appInfo;
            
            this.httpClient = new HttpClient();

            var apiKey = this.configuration.GetSetting(DataServiceConstants.APIKEY_NAME);
            this.httpClient.DefaultRequestHeaders.Add(DataServiceConstants.HEADER_API_KEY, apiKey);

            httpClient.DefaultRequestHeaders.Add(DataServiceConstants.USER_AGENT_HEADER, $"{appInfo.DeviceInfoPlatform}/{appInfo.DeviceInfoVersion} {appInfo.PackageName}/{appInfo.Version}");
        }

        public async Task<TResult> GetData<TResult>(string parameters, CancellationToken? cancellationToken = null) where TResult : class
        {
            try
            {
                var key = DataServiceConstants.BASE_URL_NAME;
                var baseUrl = this.configuration.GetSetting(key);

                var url = baseUrl + parameters;

                HttpResponseMessage response;
                if (cancellationToken is null)
                {
                    response = await this.httpClient.GetAsync(url);
                }
                else
                {
                    response = await this.httpClient.GetAsync(url, (CancellationToken)cancellationToken);
                }
                var json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default;
                    }
                    return JsonConvert.DeserializeObject<TResult>(json);
                }

                throw new Exception("Error the deserialize");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EXCEPTION ERROR: {ex.Message}");
                throw ex;
            }
        }

        public async Task<TResult> PostData<TResult, TType>(string endpoint, TType parameters, CancellationToken? cancellationToken = null) where TResult : class
        {
            try
            {
                var key = DataServiceConstants.BASE_URL_NAME;
                var baseUrl = this.configuration.GetSetting(key);

                var url = baseUrl + endpoint;

                var json = JsonConvert.SerializeObject(parameters);
                var data = new StringContent(json, Encoding.UTF8, DataServiceConstants.HEADER_CONTENT_TYPE);

                HttpResponseMessage response;
                if (cancellationToken is null)
                {
                    response = await this.httpClient.PostAsync(url, data);
                }
                else
                {
                    response = await this.httpClient.PostAsync(url, data, (CancellationToken)cancellationToken);
                }

                json = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<TResult>(json);
                }

                throw new Exception("Error the deserialize");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"EXCEPTION ERROR: {ex.Message}");
                throw ex;
            }
        }
    }
}
