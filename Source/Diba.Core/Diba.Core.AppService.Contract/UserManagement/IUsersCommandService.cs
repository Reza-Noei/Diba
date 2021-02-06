using Diba.Core.AppService.Contract.BindingModels;
using Diba.Core.AppService.Contract.ViewModels;
using System;

namespace Diba.Core.AppService.Contract
{
    public interface IUsersCommandService
    {
        ServiceResult<UserViewModel> Create(CreateUserInputModel request);
        ServiceResult<UserViewModel> Update(UpdateUserInputModel request);
        ServiceResult<UserViewModel> Delete(DeleteUserInputModel request);
        ServiceResult<CustomerViewModel> CreateCustomer(CreateCustomerInputModel model);
    }
}
