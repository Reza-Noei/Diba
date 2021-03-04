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

        public IEnumerable<string> Role
        {
            get
            {
                if (!HttpContextAccessor.HttpContext.Items.ContainsKey("Role"))
                    return new List<string> { };
                else
                    return (List<string>)HttpContextAccessor.HttpContext.Items["Role"];
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
    }
}
