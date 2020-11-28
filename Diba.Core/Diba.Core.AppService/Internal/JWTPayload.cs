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
        private const string ORGANIZATION_ID = "od";
        private const string ORGANIZATION_TITLE = "ot";
        private const string ROLE_TITLE = "ro";
        private const string USER_DISPLAYNAME = "udn";
        private const string USER_ID = "ud";
        private const string DEFAULT_ISSUER = "Diba.WebApi";

        public JWTPayload(JwtPayload token)
        {
            this[USER_ID] = token[USER_ID];
            this[USER_DISPLAYNAME] = token[USER_DISPLAYNAME];
            this[ORGANIZATION_TITLE] = token[ORGANIZATION_TITLE];
            this[ORGANIZATION_ID] = token[ORGANIZATION_ID];
            this[ROLE_TITLE] = token[ROLE_TITLE];

            this[NOT_VALID_BEFORE] = token[NOT_VALID_BEFORE];
            this[EXPIRE] = token[EXPIRE];
            this[ISSUER] = token[ISSUER];
        }

        public JWTPayload(long userId,
                          string userDisplayName,
                          long? organizationId,
                          string organizationTitle,
                          string role,
                          DateTime? expires) : base(DEFAULT_ISSUER, string.Empty, null, DateTime.UtcNow, expires)
        {
            this[USER_ID] = userId;
            this[USER_DISPLAYNAME] = userDisplayName;
            this[ORGANIZATION_ID] = organizationId;
            this[ROLE_TITLE] = role;
            this[ORGANIZATION_TITLE] = organizationTitle;
        }

        public long OrganizationId
        {
            get
            {
                long organizationId;
                long.TryParse(base[ORGANIZATION_ID]?.ToString(), out organizationId);
                return organizationId;
            }

            set { base[ORGANIZATION_ID] = value; }
        }

        public string OrganizationTitle
        {
            get { return base[ORGANIZATION_TITLE]?.ToString(); }

            set { base[ORGANIZATION_TITLE] = value; }
        }

        public string RoleTitle { get { return base[ROLE_TITLE]?.ToString(); } set { base[ROLE_TITLE] = value; } }

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
    }
}
