
using Diba.Tests.Acceptance.Feature.Product.Model;

namespace Diba.Tests.Acceptance.Feature.Product.Tasks.Posts
{
    public static class CreateProduct
    {
        public static CreateProductBy By(CreateProductCommand command) => new CreateProductBy(command);

    }
}