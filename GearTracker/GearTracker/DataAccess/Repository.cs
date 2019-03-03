using GearTracker.DataAccess.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GearTracker.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private SQLiteAsyncConnection _dbConnection;
        public Repository(SQLiteAsyncConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        #region Queries

        public async Task<TEntity> Get(int id)
        {
            return await _dbConnection.FindAsync<TEntity>(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbConnection.Table<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var table = _dbConnection.Table<TEntity>();

            if (predicate != null)
                table = table.Where(predicate);

            return await table.ToListAsync();
        }

        public async Task<TEntity> FindSingle(Expression<Func<TEntity, bool>> predicate)
        {
            var table = _dbConnection.Table<TEntity>();

            if (predicate != null)
                return await table.FirstOrDefaultAsync(predicate);
            else
                return null;
        }

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
