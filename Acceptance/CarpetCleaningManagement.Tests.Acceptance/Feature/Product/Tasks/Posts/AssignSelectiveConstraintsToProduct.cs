
using Diba.Tests.Acceptance.Feature.Product.Model;

namespace Diba.Tests.Acceptance.Feature.Product.Tasks.Posts
{
    public class AssignSelectiveConstraintsToProduct
    {
        public static AssignSelectiveConstraintsToProductBy By(SelectiveConstraintsCommand command) => new AssignSelectiveConstraintsToProductBy(command);

    }
}