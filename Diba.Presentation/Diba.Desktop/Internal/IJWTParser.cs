using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diba.Desktop.Internal
{
    internal interface IJWTParser
    {
        TokenPayload Parse(string AccessToken);
    }

    internal class JWTParser : IJWTParser
    {
        public TokenPayload Parse(string AccessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.ReadJwtToken(AccessToken);

            return new TokenPayload()
            {
                UserName = token.Payload["udn"].ToString(),
                UserId = long.Parse(token.Payload["ud"].ToString()),
                OrganizationTitle = token.Payload["ot"].ToString(),
                OrganizationId = long.Parse(token.Payload["od"].ToString())
            };
        }
    }

    internal class MockJWTParser : IJWTParser
    {
        public TokenPayload Parse(string AccessToken)
        {
            return new TokenPayload()
            {
                UserId = 1,
                UserName = "سعید احمدی",
                OrganizationTitle = "قالیشویی مون",
                OrganizationId = 2
            };
        }
    }

    public class TokenPayload
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public long OrganizationId { get; set; }
        public string OrganizationTitle { get; set; }
    }
}
