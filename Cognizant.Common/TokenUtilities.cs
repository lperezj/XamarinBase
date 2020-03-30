using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Cognizant.DataService.Entities;
using JWT;
using JWT.Serializers;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cognizant.Common
{
    public static class TokenUtilities
    {
        public static DateTime GetExpirationDate(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
            var date = jsonToken.ValidTo;

            return date;
        }

        public static string GenerateNewToken(DateTime expirationDate)
        {
            try
            {
                var claimsIdentity = new ClaimsIdentity(new[]
                {
                    new Claim("accountType", "UserAccount", ClaimValueTypes.String),
                    new Claim("memberNumber", "0001500190", ClaimValueTypes.String),
                    new Claim("userId", Guid.NewGuid().ToString(), ClaimValueTypes.String),
                    new Claim("languageCode", "N", ClaimValueTypes.String),
                    new Claim("companies", "0000008684", ClaimValueTypes.String),
                    new Claim("memberType", "Member", ClaimValueTypes.String),
                    new Claim("jti", Guid.NewGuid().ToString(), ClaimValueTypes.String),
                    new Claim("iss", "http://localhost:5020/", ClaimValueTypes.String),
                    new Claim("aud", "http://localhost:5020/", ClaimValueTypes.String),
                    new Claim("exp", EpochTime.GetIntDate(expirationDate).ToString(), ClaimValueTypes.Integer64),
                    new Claim("nbf", EpochTime.GetIntDate(DateTime.Now).ToString(), ClaimValueTypes.Integer64)
                });


                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                    subject: claimsIdentity,
                    notBefore: DateTime.UtcNow,
                    expires: expirationDate);

                var tokenString = tokenHandler.WriteToken(jwtSecurityToken);

                return tokenString;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return string.Empty;
            }
        }

        public static bool TokenIsValid(string token, string expirationString)
        {
            if (string.IsNullOrEmpty(token))
            {
                return false;
            }

            var parsed = DateTime.TryParse(expirationString, out var expirationDate);
            if (parsed)
            {
                return DateTime.Now < expirationDate;
            }
            return false;
        }

        public static TokenEntity DeserializeToken(string token)
        {
            JsonSerializer customJsonSerializer = new JsonSerializer
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                NullValueHandling = NullValueHandling.Ignore
            };

            try
            {
                IJsonSerializer serializer = new JsonNetSerializer(customJsonSerializer);
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

                var tok = decoder.DecodeToObject<TokenEntity>(token);
                return tok;
            }
            catch (TokenExpiredException)
            {
                Console.WriteLine("Token has expired");
                throw;
            }
            catch (SignatureVerificationException)
            {
                Console.WriteLine("Token has invalid signature");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }                       
        }
    }
}
