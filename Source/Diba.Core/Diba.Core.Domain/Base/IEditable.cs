using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Domain.Base
{
    public interface IEditable: ICreatable
    {
        User Modifier { get; set; }
        DateTime Modification { get; set; }
    }
}
