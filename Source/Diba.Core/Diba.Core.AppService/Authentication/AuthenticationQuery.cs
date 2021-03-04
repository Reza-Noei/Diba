using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Dependencies;
using Diba.Core.AppService.Internal;
using System.Collections.Generic;

namespace Diba.Core.AppService
{
    public class AuthenticationQuery : BaseService, IAuthenticationQuery
    {
        private readonly IJsonWebTokenEngine _jsonWebTokenEngine;

        public AuthenticationQuery(IAuthenticationInformation authenticationInformation,
                                   IJsonWebTokenEngine jsonWebTokenEngine)
                                   : base(authenticationInformation)
        {
            _jsonWebTokenEngine = jsonWebTokenEngine;
        }

        public ServiceResult<bool> ValidToken(string Token, out long UserId, out IEnumerable<string> Role)
        {
            UserId = 0;
            Role = new List<string> { };

            try
            {
                JWTPayload Payload;

                var result = _jsonWebTokenEngine.ValidateToken(Token, out Payload);
                if (!result)
                    return new ServiceResult<bool>(false)
                    {
                        Message = new InvalidTokenMessage(),
                        StatusCode = StatusCode.Forbidden
                    };

                UserId = Payload.UserId;
                Role = Payload.RoleTitle;

                return new ServiceResult<bool>(true);
            }
            catch
            {
                Role = new List<string> { };
                return new ServiceResult<bool>(false)
                {
                    Message = new InvalidTokenMessage(),
                    StatusCode = StatusCode.Forbidden
                };
            }
        }
    }
}
