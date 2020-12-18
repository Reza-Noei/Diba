using Diba.Core.AppService.Dependencies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Internal
{
    public class BaseService
    {
        protected readonly IAuthenticationInformation AuthenticationInformation;

        public BaseService(IAuthenticationInformation authenticationInformation)
        {
            AuthenticationInformation = authenticationInformation;
        }
    }
}
