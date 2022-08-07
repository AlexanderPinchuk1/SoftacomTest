using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Library.Repositories.Intefaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> AllAsync();

        Task<T> GetByIdAsync(Guid id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}