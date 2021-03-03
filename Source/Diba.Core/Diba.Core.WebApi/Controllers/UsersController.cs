using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.ViewModels;
using Diba.Core.WebApi.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Diba.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersCommandService _usersCommandService;
        private readonly IUsersQueryService _usersQueryService;

        public UsersController(IUsersCommandService usersCommandService, IUsersQueryService usersQueryService)
        {
            _usersCommandService = usersCommandService;
            _usersQueryService = usersQueryService;
        }

        #region user

        [HttpGet]
        [Route("{id}")]
        public ServiceResult<UserViewModel> Get(long id)
        {
            var user = _usersQueryService.Get(new GetUserInputModel() { Id = id });
            return user;
        }

        [HttpGet]
        [AllowAnonymous]
        public ServiceResult<IList<UserViewModel>> GetAll()
        {
            ServiceResult<IList<UserViewModel>> users = _usersQueryService.GetAll(new GetAllUserInputModel() { });
            return users;
        }

        [Scope("addUser")]
        [HttpPost]
        public ServiceResult<UserViewModel> Create(CreateUserInputModel model)
        {
            ServiceResult<UserViewModel> response = _usersCommandService.Create(model);
            return response;
        }

        [HttpPatch]
        [AllowAnonymous]
        [Route("{id}")]
        public ServiceResult<UserViewModel> Update(long id, UpdateUserInputModel model)
        {
            var request = new UpdateUserRequest { Id = id, Username = model.Username };
            ServiceResult<UserViewModel> response = _usersCommandService.Update(request);
            return response;
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("{id}")]
        public ServiceResult<UserViewModel> Delete(long id)
        {
            var user = _usersCommandService.Delete(new DeleteUserInputModel() { Id = id });
            return user;
        }

        #endregion

        #region customer
        [HttpGet]
        [AllowAnonymous]
        [Route("Customers")]
        public ServiceResult<IList<CustomerViewModel>> GetAllCustomer()
        {
            ServiceResult<IList<CustomerViewModel>> response = _usersQueryService.GetAllCustomer();
            return response;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("{userId}/Customer")]
        public ServiceResult<CustomerViewModel> CreateCustomer(int userId, CreateCustomerInputModel model)
        {
            ServiceResult<CustomerViewModel> response = _usersCommandService.CreateCustomer(userId, model);
            return response;
        }

        [HttpPatch]
        [AllowAnonymous]
        [Route("{userId}/Customer")]
        public ServiceResult<CustomerViewModel> UpdateCustomer(long userId, UpdateCustomerInputModel model)
        {
            ServiceResult<CustomerViewModel> response = _usersCommandService.UpdateCustomer(userId, model);
            return response;
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("{userId}/Customer")]
        public ServiceResult<CustomerViewModel> DeleteCustomer(long userId)
        {
            ServiceResult<CustomerViewModel> response = _usersCommandService.DeleteCustomer(userId);
            return response;
        }

        #endregion

        #region Admin

        [HttpGet]
        [AllowAnonymous]
        [Route("{userId}/admins")]
        public ServiceResult<AdminViewModel> GetAdminByUserId(long userId)
        {
            ServiceResult<AdminViewModel> response = _usersCommandService.GetAdminByUserId(userId);
            return response;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("admins")]
        public ServiceResult<IList<AdminViewModel>> GetAllAdmins()
        {
            ServiceResult<IList<AdminViewModel>> response = _usersCommandService.GetAllAdmins();
            return response;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("{userId}/admin")]
        public ServiceResult<AdminViewModel> CreateAdmin(long userId, CreateAdminInputModel model)
        {
            ServiceResult<AdminViewModel> response = _usersCommandService.CreateAdmin(userId);
            return response;
        }

        [HttpPatch]
        [AllowAnonymous]
        [Route("{userId}/admin")]
        public ServiceResult<AdminViewModel> UpdateAdmin(long userId, UpdateAdminInputModel model)
        {
            ServiceResult<AdminViewModel> response = _usersCommandService.UpdateAdmin(userId, model);
            return response;
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("{userId}/admin")]
        public ServiceResult<AdminViewModel> DeleteAdmin(long userId)
        {
            ServiceResult<AdminViewModel> response = _usersCommandService.DeleteAdmin(userId);
            return response;
        }

        #endregion

        #region Secretary

        [HttpGet]
        [AllowAnonymous]
        [Route("{userId}/secretarys")]
        public ServiceResult<SecretaryViewModel> GetSecretaryByUserId(long userId)
        {
            ServiceResult<SecretaryViewModel> response = _usersCommandService.GetSecretaryByUserId(userId);
            return response;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("secretarys")]
        public ServiceResult<IList<SecretaryViewModel>> GetAllSecretarys()
        {
            ServiceResult<IList<SecretaryViewModel>> response = _usersCommandService.GetAllSecretarys();
            return response;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("{userId}/secretary")]
        public ServiceResult<SecretaryViewModel> CreateSecretary(long userId)
        {
            ServiceResult<SecretaryViewModel> response = _usersCommandService.CreateSecretary(userId);
            return response;
        }

        [HttpPatch]
        [AllowAnonymous]
        [Route("{userId}/secretary")]
        public ServiceResult<SecretaryViewModel> UpdateSecretary(long userId)
        {
            ServiceResult<SecretaryViewModel> response = _usersCommandService.UpdateSecretary(userId);
            return response;
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("{userId}/secretary")]
        public ServiceResult<SecretaryViewModel> DeleteSecretary(long userId)
        {
            ServiceResult<SecretaryViewModel> response = _usersCommandService.DeleteSecretary(userId);
            return response;
        }

        #endregion

        #region Collector

        [HttpGet]
        [AllowAnonymous]
        [Route("{userId}/collectors")]
        public ServiceResult<CollectorViewModel> GetCollectorByUserId(long userId)
        {
            ServiceResult<CollectorViewModel> response = _usersCommandService.GetCollectorByUserId(userId);
            return response;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("collectors")]
        public ServiceResult<IList<CollectorViewModel>> GetAllCollectors()
        {
            ServiceResult<IList<CollectorViewModel>> response = _usersCommandService.GetAllCollectors();
            return response;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("{userId}/collector")]
        public ServiceResult<CollectorViewModel> CreateCollector(long userId)
        {
            ServiceResult<CollectorViewModel> response = _usersCommandService.CreateCollector(userId);
            return response;
        }

        [HttpPatch]
        [AllowAnonymous]
        [Route("{userId}/collector")]
        public ServiceResult<CollectorViewModel> UpdateCollector(long userId)
        {
            ServiceResult<CollectorViewModel> response = _usersCommandService.UpdateCollector(userId);
            return response;
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("{userId}/collector")]
        public ServiceResult<CollectorViewModel> DeleteCollector(long userId)
        {
            ServiceResult<CollectorViewModel> response = _usersCommandService.DeleteCollector(userId);
            return response;
        }
        #endregion

        #region Delivery

        [HttpGet]
        [AllowAnonymous]
        [Route("{userId}/deliverys")]
        public ServiceResult<DeliveryViewModel> GetDeliveryByUserId(long userId)
        {
            ServiceResult<DeliveryViewModel> response = _usersCommandService.GetDeliveryByUserId(userId);
            return response;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("deliverys")]
        public ServiceResult<IList<DeliveryViewModel>> GetAllDeliverys()
        {
            ServiceResult<IList<DeliveryViewModel>> response = _usersCommandService.GetAllDeliverys();
            return response;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("{userId}/delivery")]
        public ServiceResult<DeliveryViewModel> CreateDelivery(long userId)
        {
            ServiceResult<DeliveryViewModel> response = _usersCommandService.CreateDelivery(userId);
            return response;
        }

        [HttpPatch]
        [AllowAnonymous]
        [Route("{userId}/delivery")]
        public ServiceResult<DeliveryViewModel> UpdateDelivery(long userId)
        {
            ServiceResult<DeliveryViewModel> response = _usersCommandService.UpdateDelivery(userId);
            return response;
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("{userId}/delivery")]
        public ServiceResult<DeliveryViewModel> DeleteDelivery(long userId)
        {
            ServiceResult<DeliveryViewModel> response = _usersCommandService.DeleteDelivery(userId);
            return response;
        }
        #endregion

        #region SuperAdmin

        [HttpGet]
        [AllowAnonymous]
        [Route("{userId}/superAdmins")]
        public ServiceResult<SuperAdminViewModel> GetSuperAdminByUserId(long userId)
        {
            ServiceResult<SuperAdminViewModel> response = _usersCommandService.GetSuperAdminByUserId(userId);
            return response;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("superAdmins")]
        public ServiceResult<IList<SuperAdminViewModel>> GetAllSuperAdmins()
        {
            ServiceResult<IList<SuperAdminViewModel>> response = _usersCommandService.GetAllSuperAdmins();
            return response;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("{userId}/superAdmin")]
        public ServiceResult<SuperAdminViewModel> CreateSuperAdmin(long userId)
        {
            ServiceResult<SuperAdminViewModel> response = _usersCommandService.CreateSuperAdmin(userId);
            return response;
        }

        [HttpPatch]
        [AllowAnonymous]
        [Route("{userId}/superAdmin")]
        public ServiceResult<SuperAdminViewModel> UpdateSuperAdmin(long userId)
        {
            ServiceResult<SuperAdminViewModel> response = _usersCommandService.UpdateSuperAdmin(userId);
            return response;
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("{userId}/superAdmin")]
        public ServiceResult<SuperAdminViewModel> DeleteSuperAdmin(long userId)
        {
            ServiceResult<SuperAdminViewModel> response = _usersCommandService.DeleteSuperAdmin(userId);
            return response;
        }
        #endregion
    }
}