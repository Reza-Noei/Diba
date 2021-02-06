using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diba.Core.AppService;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.BindingModels;
using Diba.Core.AppService.Contract.ViewModels;
using Diba.Core.WebApi.Internal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diba.Core.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUsersCommandService _userManagementCommand;
        public UserManagementController(IUsersCommandService userManagementCommand)
        {
            _userManagementCommand = userManagementCommand;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        //// POST api/values
        //[HttpPost]
        //[AllowAnonymous]
        //public ServiceResult<UserViewModel> Post([FromBody] CreateUserBindingModel model)
        //{
        //    return _userManagementCommand.Create(model);
        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
