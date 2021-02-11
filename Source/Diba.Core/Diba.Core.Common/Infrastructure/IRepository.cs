using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Diba.Core.Common.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(long id);
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
