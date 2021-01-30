using Diba.Core.AppService.Dependencies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Diba.Core.WebApi.Internal
{
    public class AuthenticationInformation: IAuthenticationInformation
    {
        private readonly IHttpContextAccessor HttpContextAccessor;
        public AuthenticationInformation(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public string Role
        {
            get
            {
                if (!HttpContextAccessor.HttpContext.Items.ContainsKey("Role"))
                    return string.Empty;
                else
                    return HttpContextAccessor.HttpContext.Items["Role"].ToString();
            }

            set
            {
                HttpContextAccessor.HttpContext.Items["Role"] = value;
            }
        }

        public long? UserId
        {
            get
            {
                if (!HttpContextAccessor.HttpContext.Items.ContainsKey("UserId"))
                    return null;
                else
                    return long.Parse(HttpContextAccessor.HttpContext.Items["UserId"].ToString());
            }

            set
            {
                HttpContextAccessor.HttpContext.Items["UserId"] = value.ToString();
            }
        }

        public long? OrganizationId
        {
            get
            {
                if (!HttpContextAccessor.HttpContext.Items.ContainsKey("OrganizationId"))
                    return null;
                else
                    return long.Parse(HttpContextAccessor.HttpContext.Items["OrganizationId"].ToString());
            }

            set
            {
                HttpContextAccessor.HttpContext.Items["OrganizationId"] = value.ToString();
            }
        }
    }
}
