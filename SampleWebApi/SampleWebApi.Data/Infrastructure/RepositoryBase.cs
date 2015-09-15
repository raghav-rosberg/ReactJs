using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Data.Infrastructure
{
    public class RepositoryBase<TEntity> : Disposable, IRepository<TEntity> where TEntity : class
    {
        private readonly System.Data.Entity.DbContext m_dataContext;

        private IDbSet<TEntity> Dbset
        {
            get { return m_dataContext.Set<TEntity>(); }
        }

        public RepositoryBase(System.Data.Entity.DbContext dbContext)
        {
            m_dataContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Dbset.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> @where)
        {
            return await Dbset.FirstOrDefaultAsync(where);
        }

        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> @where, int take = 0)
        {
            return take <= 0 ? await Dbset.Where(where).ToListAsync() : await Dbset.Where(where).Take(take).ToListAsync();
        }

        public async Task<List<TResult>> GetManyAsync<TResult>(Expression<Func<TEntity, bool>> @where, Expression<Func<TEntity, TResult>> @select, int take = 0)
        {
            return take <= 0 ? await Dbset.Where(@where).Select(@select).ToListAsync() : await Dbset.Where(@where).Select(@select).Take(take).ToListAsync();
        }

        public async Task<int> GetAllCountAsync()
        {
            return await Dbset.CountAsync();
        }

        public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> @where)
        {
            return await Dbset.CountAsync(where);
        }

        public void Insert(TEntity entity)
        {
            Dbset.Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            Dbset.Attach(entity);
            m_dataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = Dbset.Find(id);
            if (entity == null)
                throw new ObjectNotFoundException("entity");
            Dbset.Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            Dbset.Remove(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> @where)
        {
            var objects = Dbset.Where(where).AsEnumerable();
            foreach (var obj in objects)
                Dbset.Remove(obj);
        }
    }
}
