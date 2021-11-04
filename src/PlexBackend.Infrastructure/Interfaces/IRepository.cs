using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PlexBackend.Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> FindAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T GetById(int id);
        T Create(T entity);
        void AddRange(List<T> entities);
        public void UpdateRange(List<T> entitites);
        void Update(T entity);
        void Delete(T entity);
        void Save();
        void Dispose();
    }
}
