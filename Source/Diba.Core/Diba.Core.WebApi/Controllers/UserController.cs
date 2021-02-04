using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.BindingModels;
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
        private readonly IUserManagementCommand _userManagementCommand;
        private readonly IUserManagementQuery _userManagementQuery;

        public UserController(IUserManagementCommand userManagementCommand, IUserManagementQuery userManagementQuery)
        {
            _userManagementCommand = userManagementCommand;
            _userManagementQuery = userManagementQuery;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        public ServiceResult<UserViewModel> Get(long id)
        {
            var user = _userManagementQuery.Get(new GetUserBindingModel() { Id = id });
            return user;
        }

        [HttpGet]
        [AllowAnonymous]
        public ServiceResult<IList<UserViewModel>> GetAll()
        {
            ServiceResult<IList<UserViewModel>> users = _userManagementQuery.GetAll(new GetAllUserBindingModel() { });
            return users;
        }

        [HttpPost]
        [AllowAnonymous]
        public ServiceResult<UserViewModel> Create(CreateUserBindingModel model)
        {
            ServiceResult<UserViewModel> response = _userManagementCommand.Create(model);
            return response;
        }

        [HttpPatch]
        [AllowAnonymous]
        public ServiceResult<UserViewModel> Update(UpdateUserBindingModel model)
        {
            ServiceResult<UserViewModel> response = _userManagementCommand.Update(model);
            return response;
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("{id}")]
        public ServiceResult<UserViewModel> Delete(long id)
        {
            var user = _userManagementCommand.Delete(new DeleteUserBindingModel() { Id = id });
            return user;
        }
    }
}