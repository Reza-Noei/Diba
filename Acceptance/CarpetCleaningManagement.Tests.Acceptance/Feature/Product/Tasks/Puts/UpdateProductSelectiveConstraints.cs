using Diba.Tests.Acceptance.Feature.Product.Model;

namespace Diba.Tests.Acceptance.Feature.Product.Tasks.Puts
{
    public class UpdateProductSelectiveConstraints
    {
        public static ProductSelectiveConstraintsBy By(ProductSelectiveConstraintsUpdateCommand command) => new ProductSelectiveConstraintsBy(command);
    }
}