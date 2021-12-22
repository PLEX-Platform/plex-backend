using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Core.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T GetById(int id);
        T GetById(Guid id);
        Task<T> Create(T entity);
        void AddRange(List<T> entities);
        public void UpdateRange(List<T> entitites);
        void Update(T entity);
        void Delete(T entity);
        Task Save();
        void Dispose();
    }
}
