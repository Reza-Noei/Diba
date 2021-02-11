using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Diba.Core.Common.Infrastructure
{
    public abstract partial class RepositoryBase<T> : IRepository<T> where T : class
    {
        private DbContext _dataContext;
        private readonly IUnitOfWork _unitOfWork;
        protected readonly DbSet<T> dbSet;

        protected DbContext DataContext => _dataContext ?? (_dataContext = DatabaseFactory.Get());
        protected IDatabaseFactory DatabaseFactory { get; private set; }


        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbSet = DataContext.Set<T>();
        }

        protected RepositoryBase(IDatabaseFactory databaseFactory, IUnitOfWork unitOfWork) : this(databaseFactory)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }


        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            var objects = dbSet.Where(where).AsEnumerable();
            foreach (var obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetById(long id)
        {
            return dbSet.Find(id);
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.FirstOrDefault(where);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
