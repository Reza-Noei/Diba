using Diba.Core.AppService.Contract.BindingModels;
using Diba.Core.AppService.Contract.ViewModels;
using System.Collections.Generic;

namespace Diba.Core.AppService.Contract
{
    public interface IUsersQueryService
    {
        ServiceResult<UserViewModel> Get(GetUserInputModel request);
        ServiceResult<IList<UserViewModel>> GetAll(GetAllUserInputModel request);

        ServiceResult<CustomerViewModel> GetCustomer(GetCustomerInputModel request);
        ServiceResult<IList<CustomerViewModel>> GetAllCustomer(GetAllCustomersInputModel request);
    }
}