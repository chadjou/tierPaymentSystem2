using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PaymentSystem2DAL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Commit();
        Task CommitAsync();
        int Count();
        Task<int> CountAsync();
        void Delete(object id, bool saveChanges = false);
        void Delete(TEntity entity, bool saveChanges = false);
        Task DeleteAsync(object id, bool saveChanges = false);
        Task DeleteAsync(TEntity entity, bool saveChanges = false);
        void Dispose();
        TEntity Find(Expression<Func<TEntity, bool>> match);
        Task<IList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);
        IList<TEntity> GetAll();
        Task<IList<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        IList<TEntity> GetAllMatched(Expression<Func<TEntity, bool>> match);
        IList<TEntity> GetAllPaged(int pageIndex, int pageSize, out int totalCount);
        Task<IList<TEntity>> GetAllWithIncludes(string include);
        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);
        IQueryable<TEntity> GetIQueryable();
        object Insert(TEntity entity, bool saveChanges = false);
        Task<object> InsertAsync(TEntity entity, bool saveChanges = false);
        void Update(TEntity entity, bool saveChanges = false);
        TEntity Update(TEntity entity, object key, bool saveChanges = false);
        Task UpdateAsync(TEntity entity, bool saveChanges = false);
        Task<TEntity> UpdateAsync(TEntity entity, object key, bool saveChanges = false);
    }
}