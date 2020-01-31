using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DealDouble.Services.IRepository
{
    public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetByFiler(Func<T, bool> predicate);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        int Count(Func<T, bool> predicate);
    }
}