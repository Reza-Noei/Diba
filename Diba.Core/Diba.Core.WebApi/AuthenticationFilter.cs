using Diba.Core.AppService;
using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Dependencies;
using Diba.Core.Common.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Diba.Core.Service
{
    public partial class Startup
    {
        public class AuthenticationFilter : IAuthorizationFilter
        {
            private readonly IAuthenticationCommand _authenticationCommand;
            private readonly IAuthenticationQuery _authenticationQuery;
            private readonly IAuthenticationInformation _authenticationInformation;

            public AuthenticationFilter(IAuthenticationInformation authenticationInformation, IAuthenticationCommand authenticationCommand, IAuthenticationQuery authenticationQuery)
            {
                _authenticationCommand = authenticationCommand;
                _authenticationQuery = authenticationQuery;
                _authenticationInformation = authenticationInformation;
            }

            public void OnAuthorization(AuthorizationFilterContext context)
            {
                var accessToken = context.HttpContext.Request.Headers["Authorization"];

                var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
                if (controllerActionDescriptor != null)
                {
                    var allowAnonymous = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true).Any(P=> P is Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute);
                    if (allowAnonymous)
                        return;

                    var firstStepLoginAuthorization = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true).Any(P => P is FirstStepLoginAuthorizationAttribute);
                    if (firstStepLoginAuthorization)
                    {
                        long userId;
                        long? organizationId;
                        string role;

                        var validationResult = _authenticationQuery.ValidToken(Token: accessToken, out userId, out organizationId, out role);
                        if (validationResult.StatusCode != StatusCode.Ok)
                        {
                            ActionResult<ServiceResult<bool>> A = new ActionResult<ServiceResult<bool>>(validationResult);
                            context.Result = new UnauthorizedObjectResult(A);
                        }

                        _authenticationInformation.OrganizationId = organizationId;
                        _authenticationInformation.UserId = userId;
                        _authenticationInformation.Role = role;
                        return;
                    }
                }
                

                long UserId; 
                long? OrganizationId;
                string Role;

                var ValidationResult = _authenticationQuery.ValidToken(Token: accessToken, out UserId, out OrganizationId, out Role);
                
                if (ValidationResult.StatusCode != StatusCode.Ok)
                {
                    ActionResult<ServiceResult<bool>> A = new ActionResult<ServiceResult<bool>>(ValidationResult);
                    context.Result = new UnauthorizedObjectResult(A);
                }
                else if (OrganizationId == null)
                {
                    ActionResult<ServiceResult<bool>> A = new ActionResult<ServiceResult<bool>>(ValidationResult);
                    context.Result = new UnauthorizedObjectResult(A);
                }
                else
                {
                    _authenticationInformation.OrganizationId = OrganizationId;
                    _authenticationInformation.UserId = UserId;
                    _authenticationInformation.Role = Role;
                }
            }
        }
    }
}
