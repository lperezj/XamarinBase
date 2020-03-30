using System;
using Newtonsoft.Json;

namespace FC.Weidekalender.DataService.Entities
{
    public class StatementEntity
    {

        [JsonProperty("statute")]
        public string Statute { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("dateGranted")]
        public DateTimeOffset? DateGranted { get; set; }

        [JsonProperty("dateRevoked")]
        public object DateRevoked { get; set; }

        [JsonProperty("dateFirstGrazing")]
        public DateTimeOffset? DateFirstGrazing { get; set; }

        [JsonProperty("registrationType")]
        public string RegistrationType { get; set; }

        [JsonProperty("milkSystemType")]
        public string MilkSystemType { get; set; }

        [JsonProperty("surfacePasture")]
        public long SurfacePasture { get; set; }

        [JsonProperty("surfaceLot")]
        public long SurfaceLot { get; set; }

        [JsonProperty("supplierDigitalRegistration")]
        public object SupplierDigitalRegistration { get; set; }

        [JsonProperty("supplierDigitalRegistrationName")]
        public object SupplierDigitalRegistrationName { get; set; }

        [JsonProperty("amountMilkingCows")]
        public long AmountMilkingCows { get; set; }

        [JsonProperty("amountYoungCattle")]
        public long AmountYoungCattle { get; set; }

        [JsonProperty("amountDryCattle")]
        public long AmountDryCattle { get; set; }

        [JsonProperty("amountOtherCattle")]
        public long AmountOtherCattle { get; set; }

        [JsonProperty("distanceCompanyPlot")]
        public long DistanceCompanyPlot { get; set; }

        [JsonProperty("userNumber")]
        public string UserNumber { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("modifiedDate")]
        public DateTimeOffset? ModifiedDate { get; set; }

        [JsonProperty("canEdit")]
        public bool CanEdit { get; set; }

        public bool IsProweideland { get; set; }
    }
}
