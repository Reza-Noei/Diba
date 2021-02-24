using Diba.Core.AppService.Contract.ViewModels;
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
        ServiceResult<CustomerViewModel> CreateCustomer(long userId, CreateCustomerInputModel model);
        ServiceResult<CustomerViewModel> UpdateCustomer(long userId, UpdateCustomerInputModel model);
        ServiceResult<CustomerViewModel> DeleteCustomer(long userId);

        ServiceResult<SecretaryViewModel> GetSecretaryByUserId(long userId);
        ServiceResult<IList<SecretaryViewModel>> GetAllSecretarys();
        ServiceResult<SecretaryViewModel> CreateSecretary(long userId);
        ServiceResult<SecretaryViewModel> UpdateSecretary(long userId);
        ServiceResult<SecretaryViewModel> DeleteSecretary(long userId);

        ServiceResult<DeliveryViewModel> GetDeliveryByUserId(long userId);
        ServiceResult<IList<DeliveryViewModel>> GetAllDeliverys();
        ServiceResult<DeliveryViewModel> CreateDelivery(long userId);
        ServiceResult<DeliveryViewModel> UpdateDelivery(long userId);
        ServiceResult<DeliveryViewModel> DeleteDelivery(long userId);


        ServiceResult<CollectorViewModel> GetCollectorByUserId(long userId);
        ServiceResult<IList<CollectorViewModel>> GetAllCollectors();
        ServiceResult<CollectorViewModel> CreateCollector(long userId);
        ServiceResult<CollectorViewModel> UpdateCollector(long userId);
        ServiceResult<CollectorViewModel> DeleteCollector(long userId); 
        

        ServiceResult<SuperAdminViewModel> GetSuperAdminByUserId(long userId);
        ServiceResult<IList<SuperAdminViewModel>> GetAllSuperAdmins();
        ServiceResult<SuperAdminViewModel> CreateSuperAdmin(long userId);
        ServiceResult<SuperAdminViewModel> UpdateSuperAdmin(long userId);
        ServiceResult<SuperAdminViewModel> DeleteSuperAdmin(long userId);

    }
}
