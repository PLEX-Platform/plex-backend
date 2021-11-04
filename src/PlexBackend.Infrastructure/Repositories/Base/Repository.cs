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
        public IEnumerable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().ToList();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).ToList();
        }

        public T GetById(int id)
        {
            return this.RepositoryContext.Set<T>().Find(id);
        }

        public T Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
            return entity;
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

        public void Save()
        {
            this.RepositoryContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.RepositoryContext.DisposeAsync();
        }
    }
}
