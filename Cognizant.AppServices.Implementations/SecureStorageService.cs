using System;
using System.Threading.Tasks;
using Cognizant.AppServices.Contracts;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace Cognizant.AppServices.Implementations
{
    public class SecureStorageService : ISecureStorageService
    {
        public async Task<T> Get<T>(string key)
        {
            try
            {
                var content = await SecureStorage.GetAsync(key);
                if (string.IsNullOrEmpty(content))
                {
                    return default;
                }
                else
                {
                    var value = JsonConvert.DeserializeObject<T>(content);
                    return value;
                }
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public bool Remove(string key)
        {
            return SecureStorage.Remove(key);
        }

        public Task RemoveAll()
        {
            SecureStorage.RemoveAll();

            return Task.CompletedTask;
        }

        public async Task Set<T>(string key, T value)
        {
            try
            {
                var content = JsonConvert.SerializeObject(value);

                await SecureStorage.SetAsync(key, content);
            }
            catch (Exception)
            {
                SecureStorage.Remove(key);
            }
        }
    }
}
