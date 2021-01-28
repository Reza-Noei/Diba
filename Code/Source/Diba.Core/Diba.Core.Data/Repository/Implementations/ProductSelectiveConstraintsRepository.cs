using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain.Products.ProductConstraints;

namespace Diba.Core.Data.Repository.Implementations
{
    public class ProductSelectiveConstraintsRepository : RepositoryBase<SelectiveConstraint>, IProductSelectiveConstraintsRepository
    {
        public ProductSelectiveConstraintsRepository(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {

        }

        public SelectiveConstraint GetById(int id)
        {
            return dbSet.Find(id);
        }
    }
}