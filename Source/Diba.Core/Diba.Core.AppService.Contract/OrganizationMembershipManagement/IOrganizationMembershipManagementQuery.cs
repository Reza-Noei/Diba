using Diba.Core.AppService.Contract.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract
{
    public interface IOrganizationMembershipManagementQuery
    {
        ServiceResult<IEnumerable<OrganizationMembershipViewModel>> GetUserMemberships();
    }
}