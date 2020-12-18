using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract.ViewModels
{
    public class OrganizationMembershipViewModel
    {
        public string UserDisplayName { get; set; }
        public long UserId { get; set; }
        public string OrganizationTitle { get; set; }
        public long OrganizationId { get; set; }
        public string RoleTitle { get; set; }
    }
}
