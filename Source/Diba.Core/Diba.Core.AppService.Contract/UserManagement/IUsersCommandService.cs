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
        ServiceResult<CustomerViewModel> CreateCustomer(int userId, CreateCustomerInputModel model);
        ServiceResult<CustomerViewModel> UpdateCustomer(long userId, UpdateCustomerInputModel model);
        ServiceResult<CustomerViewModel> DeleteCustomer(long userId);

        ServiceResult<SecretaryViewModel> GetSecretaryByUserId(long userId);
        ServiceResult<IList<SecretaryViewModel>> GetAllSecretarys();
        ServiceResult<SecretaryViewModel> CreateSecretary(int userId, CreateSecretaryInputModel model);
        ServiceResult<SecretaryViewModel> UpdateSecretary(long userId, UpdateSecretaryInputModel model);
        ServiceResult<SecretaryViewModel> DeleteSecretary(long userId);

        ServiceResult<DeliveryViewModel> GetDeliveryByUserId(long userId);
        ServiceResult<IList<DeliveryViewModel>> GetAllDeliverys();
        ServiceResult<DeliveryViewModel> CreateDelivery(int userId, CreateDeliveryInputModel model);
        ServiceResult<DeliveryViewModel> UpdateDelivery(long userId, UpdateDeliveryInputModel model);
        ServiceResult<DeliveryViewModel> DeleteDelivery(long userId);

        ServiceResult<CollectorViewModel> GetCollectorByUserId(long userId);
        ServiceResult<IList<CollectorViewModel>> GetAllCollectors();
        ServiceResult<CollectorViewModel> CreateCollector(int userId, CreateCollectorInputModel model);
        ServiceResult<CollectorViewModel> UpdateCollector(long userId, UpdateCollectorInputModel model);
        ServiceResult<CollectorViewModel> DeleteCollector(long userId); 
        
        ServiceResult<SuperAdminViewModel> GetSuperAdminByUserId(long userId);
        ServiceResult<IList<SuperAdminViewModel>> GetAllSuperAdmins();
        ServiceResult<SuperAdminViewModel> CreateSuperAdmin(int userId, CreateSuperAdminInputModel model);
        ServiceResult<SuperAdminViewModel> UpdateSuperAdmin(long userId, UpdateSuperAdminInputModel model);
        ServiceResult<SuperAdminViewModel> DeleteSuperAdmin(long userId);




    }
}
