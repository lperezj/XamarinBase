using Newtonsoft.Json;

namespace FC.Weidekalender.DataService.Entities
{
    public class ProfileEntity
    {
        [JsonProperty("memberType")]
        public string MemberType { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("initials")]
        public string Initials { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("phoneCountryCode")]
        public string PhoneCountryCode { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("districtId")]
        public string DistrictId { get; set; }

        [JsonProperty("districtName")]
        public string DistrictName { get; set; }

        [JsonProperty("organisationId")]
        public string OrganisationId { get; set; }

        [JsonProperty("organisationName")]
        public string OrganisationName { get; set; }

        [JsonProperty("organisationFunctionId")]
        public string OrganisationFunctionId { get; set; }

        [JsonProperty("organisationFunctionName")]
        public string OrganisationFunctionName { get; set; }
    }
}
