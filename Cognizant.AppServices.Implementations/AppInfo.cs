
using Cognizant.AppServices.Contracts;

namespace Cognizant.AppServices.Implementations
{
    public class AppInfo : IAppInfo
    {
        public string Build => Xamarin.Essentials.AppInfo.BuildString;
        public string Name => Xamarin.Essentials.AppInfo.Name;
        public string PackageName => Xamarin.Essentials.AppInfo.PackageName;
        public string Version => Xamarin.Essentials.AppInfo.VersionString;

        public string DeviceInfoModel => Xamarin.Essentials.DeviceInfo.Model;
        public string DeviceInfoPlatform => Xamarin.Essentials.DeviceInfo.Platform.ToString();
        public string DeviceInfoVersion => Xamarin.Essentials.DeviceInfo.VersionString;
    }
}
