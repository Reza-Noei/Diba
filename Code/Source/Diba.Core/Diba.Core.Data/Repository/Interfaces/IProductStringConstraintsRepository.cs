using Diba.Core.Common.Infrastructure;
using Diba.Core.Domain.Products.ProductConstraints;

namespace Diba.Core.Data.Repository.Interfaces
{
    public interface IProductStringConstraintsRepository : IRepository<StringConstraint>
    {
        StringConstraint GetById(int id);
    }
}
