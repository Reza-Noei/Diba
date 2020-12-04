using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Data.Repository.Implementations
{
    public class AdminMembershipRepository : RepositoryBase<AdminMembership>, IAdminMembershipRepository
    {
        public AdminMembershipRepository(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {

        }
    }
}
