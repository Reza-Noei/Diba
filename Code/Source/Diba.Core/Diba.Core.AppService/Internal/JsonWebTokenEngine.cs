using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Diba.Core.AppService
{
    public class JsonWebTokenEngine : IJsonWebTokenEngine
    {
        private readonly IJsonWebTokenSetting JsonWebTokenSetting;

        public JsonWebTokenEngine(IJsonWebTokenSetting jsonWebTokenSetting)
        {
            this.JsonWebTokenSetting = jsonWebTokenSetting;
        }

        private const string VALIDISSUER = "Diba.WebApi";

        public bool ValidateToken(string TokenString, out JWTPayload Payload)
        {
            try
            {
                var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JsonWebTokenSetting.Secret));
                var Handler = new JwtSecurityTokenHandler();
                var token = Handler.ReadJwtToken(TokenString);

                var validationParams = new TokenValidationParameters()
                {
                    ValidateLifetime = true,
                    LifetimeValidator =
                    (nbf, exp, securityKey, validationpara) =>
                    {
                        if (nbf.HasValue)
                            if (DateTime.UtcNow < nbf.Value)
                                return false;

                        if (exp.HasValue)
                            if (DateTime.UtcNow > exp.Value)
                                return false;

                        return true;
                    },
                    ValidIssuer = VALIDISSUER,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    IssuerSigningKeys = new List<SecurityKey>() { SecurityKey }
                };

                SecurityToken validatedToken;
                var validate = Handler.ValidateToken(TokenString, validationParams, out validatedToken);

                var a = token.ValidFrom;
                Payload = new JWTPayload(token.Payload);
                return true;
            }
            catch (Exception Ex)
            {
                Payload = null;
                return false;
            }
        }

        public string GenerateToken(long Id, string UserDisplayName, long? OrganizationId, string OrganizationTitle, string RoleTitle)
        {
            var Payload = new JWTPayload(Id,
                                         UserDisplayName,
                                         OrganizationId,
                                         OrganizationTitle,
                                         RoleTitle,
                                         DateTime.UtcNow.AddMinutes(JsonWebTokenSetting.LifeTime));

            var Token = new JwtSecurityToken(JWTHeader.DefaultHeader(JsonWebTokenSetting.Secret), Payload);
            var Handler = new JwtSecurityTokenHandler();

            return Handler.WriteToken(Token);
        }
    }
}
