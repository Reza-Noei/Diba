using System.Collections.Generic;

namespace Diba.Tests.Acceptance.Feature.Product.Model
{
    public class SelectiveConstraintsCommand
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public IList<OptionCommand> Options { get; set; }
    }
}