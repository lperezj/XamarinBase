using System;
namespace Cognizant.AppServices.Contracts
{
    public interface IAppInfo
    {
        string Build { get; }

        string Name { get; }

        string PackageName { get; }

        string Version { get; }

        string DeviceInfoModel { get; }

        string DeviceInfoPlatform { get; }

        string DeviceInfoVersion { get; }

    }
}
