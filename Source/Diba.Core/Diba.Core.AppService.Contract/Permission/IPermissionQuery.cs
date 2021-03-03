using System.Collections.Generic;

namespace Diba.Core.AppService.Contract
{
    public interface IPermissionQuery
    {
        bool CheckIfRoleHasPermission(IEnumerable<string> role, string scopeName);
    }
}
