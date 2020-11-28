using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService
{
    internal class JWTHeader : System.IdentityModel.Tokens.Jwt.JwtHeader
    {
        private static JWTHeader defaultHeader = null;

        public JWTHeader(Microsoft.IdentityModel.Tokens.SigningCredentials credentials) : base(credentials) { }

        public static JWTHeader DefaultHeader(string Secret)
        {
            if (defaultHeader == null)
            {
                var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secret));
                defaultHeader = new JWTHeader(new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature));
            }

            return defaultHeader;
        }
    }
}
