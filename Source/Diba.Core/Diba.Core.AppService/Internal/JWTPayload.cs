using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Diba.Core.AppService
{
    public class JWTPayload : JwtPayload
    {
        private const string EXPIRE = "exp";
        private const string ISSUER = "iss";
        private const string NOT_VALID_BEFORE = "nbf";
        private const string ROLE_TITLES = "ro";
        private const string USER_DISPLAYNAME = "udn";
        private const string USER_ID = "ud";
        private const string DEFAULT_ISSUER = "Diba.WebApi";

        public JWTPayload(JwtPayload token)
        {
            this[USER_ID] = token[USER_ID];
            this[USER_DISPLAYNAME] = token[USER_DISPLAYNAME];
            this[ROLE_TITLES] = token[ROLE_TITLES];

            this[NOT_VALID_BEFORE] = token[NOT_VALID_BEFORE];
            this[EXPIRE] = token[EXPIRE];
            this[ISSUER] = token[ISSUER];
        }

        public JWTPayload(long userId,
                          string userDisplayName,
                          IEnumerable<string> roles,
                          DateTime? expires) : base(DEFAULT_ISSUER, string.Empty, null, DateTime.UtcNow, expires)
        {
            this[USER_ID] = userId;
            this[USER_DISPLAYNAME] = userDisplayName;
            this[ROLE_TITLES] = roles;
        }


        public string UserDisplayName
        {
            get { return base[USER_DISPLAYNAME]?.ToString(); }

            set { base[USER_DISPLAYNAME] = value; }
        }

        public long UserId
        {
            get
            {
                long userId;
                long.TryParse(base[USER_ID]?.ToString(), out userId);
                return userId;
            }

            set { base[USER_ID] = value; }
        }

        public IEnumerable<string> RoleTitle
        {
            get
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<string>>(base[ROLE_TITLES].ToString());
            }

            set { base[ROLE_TITLES] = value; }
        }
    }
}