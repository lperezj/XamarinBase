namespace Cognizant.AppServices.Contracts
{
    public interface IAppConfiguration
    {
        string GetSetting(string key);
    }
}
