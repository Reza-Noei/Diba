using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain.Products.ProductConstraints;

namespace Diba.Core.Data.Repository.Implementations
{
    public class ProductStringConstraintsRepository : RepositoryBase<StringConstraint>, IProductStringConstraintsRepository
    {
        public ProductStringConstraintsRepository(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {

        }

        public StringConstraint GetById(int id)
        {
            return dbSet.Find(id);
        }
    }
}