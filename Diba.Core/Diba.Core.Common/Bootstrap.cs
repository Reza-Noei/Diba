using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Common
{
    public interface IBootstrap<T>
    {
        T Object { get; }
    }
}
