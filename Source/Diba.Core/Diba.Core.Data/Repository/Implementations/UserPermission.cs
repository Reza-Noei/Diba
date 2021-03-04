using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;

namespace Diba.Core.Data.Repository.Implementations
{
    class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {

        }
    }
}