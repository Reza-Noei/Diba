﻿using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;

namespace Diba.Core.Data.Repository.Implementations
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork) :base(databaseFactory, unitOfWork)
        {

        }
    }
}