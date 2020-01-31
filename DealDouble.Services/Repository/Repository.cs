using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DealDouble.Data.DAL;
using DealDouble.Services.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DealDouble.Services.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DealDoubleContext Context;

        public Repository(DealDoubleContext context)
        {
            Context = context;
        }

        private async Task SaveAsync() => await Context.SaveChangesAsync();
       
        public int Count(Func<T, bool> predicate)
        {
            return Context.Set<T>().Where(predicate).Count();
        }

        public async Task DeleteAsync(T entity)
        {
            Context.Remove(entity);
            await SaveAsync();

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> GetByFiler(Func<T, bool> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public async Task AddAsync(T entity)
        {
            await Context.AddAsync(entity);
            await SaveAsync();

        }

        public async Task UpdateAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }


    }
}
