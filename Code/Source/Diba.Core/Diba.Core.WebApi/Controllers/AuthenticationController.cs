using Diba.Core.AppService;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Contract.BindingModels;
using Diba.Core.AppService.Contract.ViewModels;
using Diba.Core.Common.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
            return _authenticationCommand.FirstStepLogin(request);
        }

        /// <summary>
        /// ورود مرحله دوم به سامانه
        /// </summary>
        /// <param name="request">درخواست</param>
        /// <returns>توکن</returns>
        [HttpPatch]
        [FirstStepLoginAuthorization]
        public ServiceResult<string> Patch(MembershipAuthenticationBindingModel request)
        {
            return _authenticationCommand.SecondStepLogin(request);
        }

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