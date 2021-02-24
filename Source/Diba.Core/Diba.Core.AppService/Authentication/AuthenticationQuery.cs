using Diba.Core.AppService.Contract;
using Diba.Core.AppService.Dependencies;
using Diba.Core.AppService.Internal;

namespace Diba.Core.AppService
{
    public class AuthenticationQuery : BaseService, IAuthenticationQuery
    {
        private readonly IJsonWebTokenEngine _jsonWebTokenEngine;

            public AuthenticationQuery(IAuthenticationInformation authenticationInformation,
                                       IJsonWebTokenEngine jsonWebTokenEngine)
                                       :base(authenticationInformation)
        {
            _jsonWebTokenEngine = jsonWebTokenEngine;
        }

        public ServiceResult<bool> ValidToken(string Token, out long UserId, out long? OrganizationId, out string Role)
        {
            UserId = 0;
            OrganizationId = null;

            try
            {
                JWTPayload Payload;
                Role = string.Empty;

                var result =  _jsonWebTokenEngine.ValidateToken(Token, out Payload);
                if (!result)
                    return new ServiceResult<bool>(false)
                    {
                        Message = new InvalidTokenMessage(),
                        StatusCode = StatusCode.Forbidden
                    };

                UserId = Payload.UserId;
                //OrganizationId = Payload.OrganizationId;
                //Role = Payload.RoleTitle;

                return new ServiceResult<bool>(true);
            }
            catch
            {
                Role = string.Empty;
                return new ServiceResult<bool>(false)
                {
                    Message = new InvalidTokenMessage(),
                    StatusCode = StatusCode.Forbidden
                };
            }
        }
    }
}
