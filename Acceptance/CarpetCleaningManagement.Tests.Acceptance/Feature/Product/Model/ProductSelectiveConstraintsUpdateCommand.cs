using System.Collections.Generic;

namespace Diba.Tests.Acceptance.Feature.Product.Model
{
    public class ProductSelectiveConstraintsUpdateCommand
    {
        public int ProductId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<OptionCommand> Options { get; set; }
    }
}