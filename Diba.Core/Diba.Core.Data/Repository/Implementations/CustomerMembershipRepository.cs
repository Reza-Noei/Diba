using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Data.Repository.Implementations
{
    public class CustomerMembershipRepository : RepositoryBase<CustomerMembership>, ICustomerMembershipRepository
    {
        public CustomerMembershipRepository(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {

        }
    }
}
