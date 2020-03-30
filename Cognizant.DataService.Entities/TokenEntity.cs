using System;

namespace Cognizant.DataService.Entities
{
    public class TokenEntity
    {
        public string MemberNumber { get; set; }
        public Guid UserId { get; set; }
        public string LanguageCode { get; set; }
        public string CountryCode { get; set; }
        public string Companies { get; set; }
        public string MemberType { get; set; }
        public Guid Jti { get; set; }
        public long Nbf { get; set; }
        public long Exp { get; set; }
        public Uri Iss { get; set; }
        public Uri Aud { get; set; }
    }
}
