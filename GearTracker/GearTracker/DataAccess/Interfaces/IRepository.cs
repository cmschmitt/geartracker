using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GearTracker.DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        Task<TEntity> Get(int id);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
