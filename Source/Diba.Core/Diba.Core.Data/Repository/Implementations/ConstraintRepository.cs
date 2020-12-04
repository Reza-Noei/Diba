using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;
using Diba.Core.Domain.Constraints;

namespace Diba.Core.Data.Repository.Implementations
{
    public class ConstraintRepository : RepositoryBase<Constraint>, IConstraintRepository
    {
        public ConstraintRepository(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {

        }

        public Constraint GetById(int id)
        {
            return dbSet.Find(id);
        }
    }
}
