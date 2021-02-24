using System;
using System.Collections.Generic;

namespace Diba.Core.AppService
{
    public interface IJsonWebTokenEngine
    {
        bool ValidateToken(string TokenString, out JWTPayload Payload);
        string GenerateToken(long Id, string UserDisplayName, IEnumerable<string> RoleTitle);
    }
}