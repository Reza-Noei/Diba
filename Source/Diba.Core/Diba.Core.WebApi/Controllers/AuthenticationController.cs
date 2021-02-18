using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.BindingModels;
using Diba.Core.AppService.Contract.ViewModels;
using Diba.Core.Common.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Diba.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationCommand _authenticationCommand;
        private readonly IAuthenticationQuery _authenticationQuery;
        private readonly IOrganizationMembershipManagementQuery _organizationMembershipManagementQuery;
        public AuthenticationController(IAuthenticationCommand authenticationCommand,
                                        IAuthenticationQuery authenticationQuery,
                                        IOrganizationMembershipManagementQuery organizationMembershipManagementQuery)
        {
            _authenticationCommand = authenticationCommand;
            _authenticationQuery = authenticationQuery;
            _organizationMembershipManagementQuery = organizationMembershipManagementQuery;
        }

        /// <summary>
        /// ورود اولیه به سامانه
        /// </summary>
        /// <param name="request">درخواست</param>
        /// <returns>توکن</returns>
        [HttpPost]
        [AllowAnonymous]
        public ServiceResult<string> Post(UserAuthenticationBindingModel request)
        {
            return _authenticationCommand.Login(request);
        }

        ///// <summary>
        ///// ورود مرحله دوم به سامانه
        ///// </summary>
        ///// <param name="request">درخواست</param>
        ///// <returns>توکن</returns>
        //[HttpPatch]
        //[FirstStepLoginAuthorization]
        //public ServiceResult<string> Patch(MembershipAuthenticationBindingModel request)
        //{
        //    return _authenticationCommand.SecondStepLogin(request);
        //}

        /// <summary>
        /// بازیابی عضویت های کاربر
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [FirstStepLoginAuthorization]
        public ServiceResult<IEnumerable<OrganizationMembershipViewModel>> Get()
        {
            return _organizationMembershipManagementQuery.GetUserMemberships();
        }
    }
}