using System.Collections.Generic;

namespace Diba.Core.AppService.Contract
{
    public interface ICustomerManagementQuery
    {
        ServiceResult<IEnumerable<CustomerViewModel>> Search(CustomerSearchInputModel request);
    }
}
