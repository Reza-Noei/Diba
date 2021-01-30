using Diba.Core.AppService;
using Diba.Core.AppService.Contract;
using RestSharp;
using System;

namespace Diba.Desktop.Internal.DibaCore
{
    internal class CustomerManagementCommand : ICustomerManagementCommand
    {
        public ServiceResult<CustomerViewModel> Create(CreateCustomerInputModel request)
        {
            IRestRequest CreateCustomer = new RestRequest("api/CustomerManagement", method: Method.POST);
            CreateCustomer.AddJsonBody(request);
            IRestResponse<ServiceResult<CustomerViewModel>> Result = RestProvider.GetInstance().Post<ServiceResult<CustomerViewModel>>(CreateCustomer);

            if (Result != null)
            {
                return Result.Data;
            }

            throw new Exception();
        }
    }
}
