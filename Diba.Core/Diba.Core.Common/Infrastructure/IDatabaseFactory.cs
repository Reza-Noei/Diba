using Microsoft.EntityFrameworkCore;
using System;

namespace Diba.Core.Common.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        DbContext Get();
    }
}
