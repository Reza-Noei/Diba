using Diba.Core.AppService.Contract;
using Diba.Core.Data.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Diba.Core.AppService
{
    public class PermissionQuery : IPermissionQuery
    {
        private readonly IPermissionRepository _permissionRepository;

        public PermissionQuery(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public bool CheckIfRoleHasPermission(IEnumerable<string> role, string scopeName)
        {
            return _permissionRepository.GetMany(x => role.ToList().Contains(x.RoleName)).Select(x=>x.Scope).Contains(scopeName);
        }
    }
}
