using Newtonsoft.Json;

namespace FC.Weidekalender.DataService.Entities
{
    public class LoginInfoEntity
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; set; }
    }
}
