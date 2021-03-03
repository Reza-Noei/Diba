using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Dependencies;
using Diba.Core.Common.Attributes;
using Diba.Core.WebApi.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace Diba.Core.Service
{
    public partial class Startup
    {
        public class AuthenticationFilter : IAuthorizationFilter
        {
            //private readonly IAuthenticationCommand _authenticationCommand;
            private readonly IAuthenticationQuery _authenticationQuery;
            private readonly IPermissionQuery _permissionQuery;
            private readonly IAuthenticationInformation _authenticationInformation;

            public AuthenticationFilter(IAuthenticationInformation authenticationInformation, /*IAuthenticationCommand authenticationCommand,*/ IAuthenticationQuery authenticationQuery, IPermissionQuery permissionQuery)
            {
                //_authenticationCommand = authenticationCommand;
                _authenticationQuery = authenticationQuery;
                _authenticationInformation = authenticationInformation;
                _permissionQuery = permissionQuery;
            }

            public void OnAuthorization(AuthorizationFilterContext context)
            {
                var accessToken = context.HttpContext.Request.Headers["Authorization"];

                var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
                if (controllerActionDescriptor != null)
                {
                    var allowAnonymous = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true).Any(P => P is Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute);
                    if (allowAnonymous)
                        return;

                    ScopeAttribute scope = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true).FirstOrDefault(P => P is ScopeAttribute) as ScopeAttribute;
                    if (scope == null)
                        return;

                    var validationResult = _authenticationQuery.ValidToken(Token: accessToken, out long userId, out IEnumerable<string> role);
                    if (validationResult.StatusCode != StatusCode.Ok)
                    {
                        ActionResult<ServiceResult<bool>> result = new ActionResult<ServiceResult<bool>>(validationResult);
                        context.Result = new UnauthorizedObjectResult(result);
                        return;
                    }

                    string scopeName = scope.Name;

                    bool roleHasPermission = _permissionQuery.CheckIfRoleHasPermission(role, scopeName);

                    if (!roleHasPermission)
                    {
                        context.Result = new UnauthorizedResult();
                        return;
                    }

                    _authenticationInformation.UserId = userId;
                    _authenticationInformation.Role = role;
                    // }
                }

            }
        }
    }
}
