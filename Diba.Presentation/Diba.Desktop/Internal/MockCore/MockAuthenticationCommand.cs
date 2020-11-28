using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.BindingModels;
using Diba.Core.AppService.Contract.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diba.Desktop.Internal.DibaCore
{
    public class MockAuthenticationCommand: IAuthenticationCommand
    {
        public MockAuthenticationCommand()
        {

        }

        public ServiceResult<string> FirstStepLogin(UserAuthenticationBindingModel model)
        {
            return new ServiceResult<string>(StatusCode.Ok)
            {
                Data = "MockData"
            };
        }


        public ServiceResult<string> SecondStepLogin(MembershipAuthenticationBindingModel model)
        {
            return new ServiceResult<string>(StatusCode.Ok)
            {
                Data = "MockData"
            };
        }
    }

    public class MockOrganizationMembershipManagementQuery : IOrganizationMembershipManagementQuery
    {        
        public MockOrganizationMembershipManagementQuery()
        {

        }

        public ServiceResult<IEnumerable<OrganizationMembershipViewModel>> GetUserMemberships()
        {
            return new ServiceResult<IEnumerable<OrganizationMembershipViewModel>>(StatusCode.Ok)
            {
                Data = new List<OrganizationMembershipViewModel>()
                {
                    new OrganizationMembershipViewModel()
                    {
                        OrganizationId = 1,
                        OrganizationTitle = "قالیشویی بهبهان",
                        RoleTitle = "Secretary",
                        UserDisplayName = "سعید احمدی",
                        UserId = 1
                    },
                    new OrganizationMembershipViewModel()
                    {
                        OrganizationId = 2,
                        OrganizationTitle = "قالیشویی جواد و برادران بجز ممد",
                        RoleTitle = "Secretary",
                        UserDisplayName = "سعید احمدی",
                        UserId = 1
                    }
                }
            };
        }
    }
}
