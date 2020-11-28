using Microsoft.EntityFrameworkCore;

namespace Diba.Core.Common.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private DbContext _dataContext;

        protected DbContext DataContext => _dataContext ?? (_dataContext = _databaseFactory.Get());

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public void Commit()
        {
            DataContext.SaveChanges();
        }
    }
}
