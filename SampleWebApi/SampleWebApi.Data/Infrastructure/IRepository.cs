using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Data.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where);
        Task<List<TResult>> GetManyAsync<TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TResult>> @select, int take = 0);
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, int take = 0);
        Task<int> GetAllCountAsync();
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> where);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> where);
    }
}
