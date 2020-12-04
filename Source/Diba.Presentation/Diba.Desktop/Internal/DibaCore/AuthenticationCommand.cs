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
    public class AuthenticationCommand: IAuthenticationCommand
    {
        public AuthenticationCommand()
        {

        }

        public ServiceResult<string> FirstStepLogin(UserAuthenticationBindingModel model)
        {
            IRestRequest LoginRequest = new RestRequest("api/Authentication", method: Method.POST);
            LoginRequest.AddJsonBody(model);
            IRestResponse<ServiceResult<string>> Result = RestProvider.GetInstance().Post<ServiceResult<string>>(LoginRequest);

            if (Result != null)
            {
                RestProvider.Renew().AddDefaultHeader("Authorization", Result.Data.Data);
                return Result.Data;
            }

            throw new Exception();
        }


        public ServiceResult<string> SecondStepLogin(MembershipAuthenticationBindingModel model)
        {
            IRestRequest LoginRequest = new RestRequest("api/Authentication", method: Method.PATCH);
            LoginRequest.AddJsonBody(model);

            IRestResponse<ServiceResult<string>> Result = RestProvider.GetInstance().Patch<ServiceResult<string>>(LoginRequest);

            if (Result != null)
            {
                RestProvider.Renew().AddDefaultHeader("Authorization", Result.Data.Data);
                return Result.Data;
            }

            throw new Exception();
        }
    }

    public class OrganizationMembershipManagementQuery : IOrganizationMembershipManagementQuery
    {        
        public OrganizationMembershipManagementQuery()
        {

        }

        public ServiceResult<IEnumerable<OrganizationMembershipViewModel>> GetUserMemberships()
        {
            IRestRequest LoginRequest = new RestRequest("api/Authentication", method: Method.GET);

            IRestResponse<ServiceResult<IEnumerable<OrganizationMembershipViewModel>>> Result = RestProvider.GetInstance().Get<ServiceResult<IEnumerable<OrganizationMembershipViewModel>>>(LoginRequest);

            if (Result != null)
            {
                return Result.Data;
            }

            return null;
        }
    }
}
