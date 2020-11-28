using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract
{
    public interface IAuthenticationQuery
    {
        ServiceResult<bool> ValidToken(string Token, out long UserId, out long? OrganizationId, out string Role);
    }
}
