using Diba.Core.AppService.Contract;
using RestSharp;
using System.Collections.Generic;

namespace Diba.Desktop.Internal.DibaCore
{
    internal class CustomerManagementQuery : ICustomerManagementQuery
    {
        public ServiceResult<IEnumerable<CustomerViewModel>> Search(CustomerSearchInputModel request)
        {
            IRestRequest SearchCustomers = new RestRequest("api/CustomerManagement", method: Method.GET);

            IRestResponse<ServiceResult<IEnumerable<CustomerViewModel>>> Result = RestProvider.GetInstance().Get<ServiceResult<IEnumerable<CustomerViewModel>>>(SearchCustomers);

            if (Result != null)
            {
                return Result.Data;
            }

            return null;
        }
    }
}
