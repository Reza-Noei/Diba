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

        ServiceResult<AdminViewModel> GetAdminByUserId(long userId);
        ServiceResult<IList<AdminViewModel>> GetAllAdmins();
        ServiceResult<AdminViewModel> CreateAdmin(long userId);
        ServiceResult<AdminViewModel> UpdateAdmin(long userId, UpdateAdminInputModel model);
        ServiceResult<AdminViewModel> DeleteAdmin(long userId);


        ServiceResult<CustomerViewModel> GetCustomerByUserId(long userId);
        ServiceResult<IList<CustomerViewModel>> GetAllCustomers();
        ServiceResult<CustomerViewModel> CreateCustomer(int userId, CreateCustomerInputModel model);
        ServiceResult<CustomerViewModel> UpdateCustomer(long userId, UpdateCustomerInputModel model);
        ServiceResult<CustomerViewModel> DeleteCustomer(long userId);

        ServiceResult<SecretaryViewModel> GetSecretaryByUserId(long userId);
        ServiceResult<IList<SecretaryViewModel>> GetAllSecretarys();
        ServiceResult<SecretaryViewModel> CreateSecretary(int userId, CreateSecretaryInputModel model);
        ServiceResult<SecretaryViewModel> UpdateSecretary(long userId, UpdateSecretaryInputModel model);
        ServiceResult<SecretaryViewModel> DeleteSecretary(long userId);


    }
}
