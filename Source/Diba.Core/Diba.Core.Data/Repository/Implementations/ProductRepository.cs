﻿using Diba.Core.Common.Infrastructure;
using Diba.Core.Data.Repository.Interfaces;
using Diba.Core.Domain;
using Diba.Core.Domain.Products;

namespace Diba.Core.Data.Repository.Implementations
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork) : base(databaseFactory, unitOfWork)
        {

        }

        public Product GetById(int id)
        {
            return dbSet.Find(id);
        }
    }
}
