using Diba.Core.AppService.Contract.BindingModels;
using Diba.Core.AppService.Contract.ViewModels;
using System;
using System.Collections.Generic;

namespace Diba.Core.AppService.Contract
{
    public interface IUsersCommandService
    {
        ServiceResult<UserViewModel> Create(CreateUserInputModel request);
        ServiceResult<UserViewModel> Update(UpdateUserRequest request);
        ServiceResult<UserViewModel> Delete(DeleteUserInputModel request);
        ServiceResult<CustomerViewModel> CreateCustomer(int userId, CreateCustomerInputModel model);
        ServiceResult<IList<AdminViewModel>> GetAllAdmins();
        ServiceResult<AdminViewModel> CreateAdmin(long userId, CreateAdminInputModel model);
        ServiceResult<AdminViewModel> UpdateAdmin(long userId, UpdateAdminInputModel model);
        ServiceResult<AdminViewModel> DeleteAdmin(long userId);
        ServiceResult<CustomerViewModel> UpdateCustomer(long userId, UpdateCustomerInputModel model);
        ServiceResult<CustomerViewModel> DeleteCustomer(long userId);
    }
}
