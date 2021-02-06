using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Diba.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersCommandService _usersCommandService;
        private readonly IUsersQueryService _usersQueryService;

        public UserController(IUsersCommandService usersCommandService, IUsersQueryService usersQueryService)
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
        public ServiceResult<UserViewModel> Update(UpdateUserInputModel model)
        {
            ServiceResult<UserViewModel> response = _usersCommandService.Update(model);
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
        public ServiceResult<IList<CustomerViewModel>> GetAllCustomer(GetAllCustomersInputModel model)
        {
            ServiceResult<IList<CustomerViewModel>> response = _usersQueryService.GetAllCustomer(model);
            return response;
        }

        public void UpdateCustomer()
        {

        }

        public void DeleteCustomer()
        {

        }

        //[HttpPost]
        //[AllowAnonymous]
        //[Route("{userId}/Customer")]
        public ServiceResult<CustomerViewModel> CreateCustomer(int userId, CreateCustomerInputModel model)
        {
            model.UserId = userId;
            ServiceResult<CustomerViewModel> response = _usersCommandService.CreateCustomer(model);
            return response;
        }
        #endregion

        #region Admin
        public void GetAllAdmin()
        {

        }

        public void CreateAdmin()
        {

        }

        public void UpdateAdmin()
        {

        }


        public void DeleteAdmin()
        {

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