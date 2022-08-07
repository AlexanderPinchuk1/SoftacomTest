using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Library.Repositories.Intefaces;

namespace Library.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        private readonly DbSet<T> _dbSet;


        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity); ;
        }

        public virtual void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task<IEnumerable<T>> AllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
    }
}