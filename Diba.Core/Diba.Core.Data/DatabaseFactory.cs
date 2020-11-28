using Diba.Core.Common.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Data
{
    public class DatabaseFactory : IDatabaseFactory, IDisposable
    {
        private DbContext _dataContext;

        public DbContext Get() { return _dataContext ?? (_dataContext = Context.Create()); }

        public void Dispose()
        {
            if (_dataContext != null)
                _dataContext.Dispose();
        }
    }
}
