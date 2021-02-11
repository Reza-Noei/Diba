using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.ViewModels;
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
        [AllowAnonymous]
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

        [HttpPost]
        [AllowAnonymous]
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
            ServiceResult<CustomerViewModel> response = _usersCommandService.UpdateCustomer(userId , model);
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
        [Route("admins")]
        public ServiceResult<IList<AdminViewModel>> GetAllAdmins()
        {
            ServiceResult<IList<AdminViewModel>> response = _usersCommandService.GetAllAdmins();
            return response;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("{userId}/admin")]
        public ServiceResult<AdminViewModel> CreateAdmin(long userId , CreateAdminInputModel model)
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

        #endregion


        #region Secretary

        #endregion


        #region Collector

        #endregion


        #region Delivery

        #endregion

    }
}