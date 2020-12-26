namespace Diba.Tests.Acceptance.Feature.Product.Tasks.Deletes
{
    public class DeleteProduct
    {
        public static DeleteProductBy By(int id) => new DeleteProductBy(id);

    }
}