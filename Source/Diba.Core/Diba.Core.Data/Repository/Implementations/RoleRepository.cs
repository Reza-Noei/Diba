using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;

namespace Diba.Core.Data.Repository.Implementations
{
    public class RoleRepository : RepositoryBase<Role>,IRoleRepository
    {
        public RoleRepository(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {

        }
    }
}
