using System;

namespace Diba.Core.AppService
{
    public interface IJsonWebTokenEngine
    {
        bool ValidateToken(string TokenString, out JWTPayload Payload);
        string GenerateToken(long UserId, string UserDisplayName, long? OrganizationId, string OrganizationTitle, string RoleTitle);
    }
}
