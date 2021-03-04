using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Dependencies
{
    public interface IAuthenticationInformation
    {
        IEnumerable<string> Role { get; set;}
        long? UserId { get; set; }
    }
}
