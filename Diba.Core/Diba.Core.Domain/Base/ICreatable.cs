using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Domain.Base
{
    public interface ICreatable
    {
        User Creator { get; set; }
        DateTime Creation { get; set; }
    }
}
