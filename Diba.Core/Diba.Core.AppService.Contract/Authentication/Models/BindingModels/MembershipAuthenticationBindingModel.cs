using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract.BindingModels
{
    public class MembershipAuthenticationBindingModel
    {
        public long OrganizationId { get; set; }
        public string Role { get; set; }
    }
}
