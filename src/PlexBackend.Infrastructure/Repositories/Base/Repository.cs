using Microsoft.EntityFrameworkCore;
using PlexBackend.Core.Interfaces;
using PlexBackend.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Infrastructure.Repositories.Base
{
    public class Repository<T>: IRepository<T> where T: class
    {
        protected PlexContext RepositoryContext { get; set; }
        public Repository(PlexContext plexContext)
        {
            this.RepositoryContext = plexContext;
        }
        public async Task<IEnumerable<T>> FindAll()
        {
            return await this.RepositoryContext.Set<T>().ToListAsync();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).ToList();
        }

        public T GetById(int id)
        {
            return this.RepositoryContext.Set<T>().Find(id);
        }

        public T GetById(Guid id)
        {
            return this.RepositoryContext.Set<T>().Find(id);
        }

        public async Task<T> Create(T entity)
        {
            var result = await this.RepositoryContext.Set<T>().AddAsync(entity);
            return result.Entity;

        }

        public void AddRange(List<T> entities)
        {
            this.RepositoryContext.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void UpdateRange(List<T> entitites)
        {
            this.RepositoryContext.Set<T>().UpdateRange(entitites);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

        public void Delete(int id)
        {
            this.RepositoryContext.Remove(RepositoryContext.Set<T>().Find(id));
        }

        public async Task Save()
        {
            await this.RepositoryContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.RepositoryContext.DisposeAsync();
        }
    }
}
