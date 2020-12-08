using Diba.Core.Common.Infrastructure;
using Diba.Core.Domain.Products.ProductConstraints;

namespace Diba.Core.Data.Repository.Interfaces
{
    public interface IProductSelectiveConstraintsRepository : IRepository<SelectiveConstraint>
    {
        SelectiveConstraint GetById(int id);
    }
}
