using System;
using Cognizant.AppServices.Contracts;
using Microsoft.Extensions.Configuration;

namespace Cognizant.AppServices.Implementations
{
    public class AppConfiguration : IAppConfiguration
    {
        private readonly IConfigurationRoot configuration;

        public AppConfiguration(IConfigurationRoot appConfigurationRoot)
        {
            this.configuration = appConfigurationRoot;
        }

        public string GetSetting(string key)
        {
            try
            {
                return this.configuration[key];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
