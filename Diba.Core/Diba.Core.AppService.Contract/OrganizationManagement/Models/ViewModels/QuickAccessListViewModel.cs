using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract
{
    public class QuickAccessListViewModel
    {
        public IEnumerable<QNameViewModel> Items { get; set; }
    }

    public class QNameViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }
}
