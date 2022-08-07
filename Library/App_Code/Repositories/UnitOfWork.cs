using Library.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Library.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private Dictionary<string, object> _repositories;

        private readonly DbContext _dbContext;


        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Repository<T> GetRepository<T>() where T : class
        {
            if (_repositories == null)
            {
                _repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (_repositories.ContainsKey(type))
            {
                return (Repository<T>)_repositories[type];
            }

            var repositoryType = typeof(Repository<>);
            var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);
            _repositories.Add(type, repositoryInstance);

            return (Repository<T>)_repositories[type];
        }
    }
}