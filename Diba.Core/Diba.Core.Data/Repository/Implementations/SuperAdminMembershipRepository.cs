using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Diba.Core.Data.Repository.Implementations
{
    public class SuperAdminMembershipRepository : RepositoryBase<SuperAdminMembership>, ISuperAdminMembershipRepository
    {
        public SuperAdminMembershipRepository(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {

        }
    }
}
