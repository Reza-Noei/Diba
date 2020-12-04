using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diba.Core.WebApi.Internal.DependencyInjection
{
    public class ServicesConfiguration
    {
        public IEnumerable<ServiceItem> Singleton { get; set; }
        public IEnumerable<ServiceItem> Transient { get; set; }
        public IEnumerable<ServiceItem> Scoped { get; set; }
    }
}
