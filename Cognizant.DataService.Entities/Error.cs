using System;
using Newtonsoft.Json;

namespace Cognizant.DataService.Entities
{
    public class Error
    {
        public Error(string code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public Error()
        {
        }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
