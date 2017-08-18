using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Yoshi.VIN.Membership.Data.EF;
using Yoshi.VIN.Membership.Repositories.Interfaces;

namespace Yoshi.VIN.Membership.Repositories
{
    public class GenericRepositoryAsync<TEntity> : IGenericRepositoryAsync<TEntity> where TEntity : class
    {
        internal MemberContext context;
        internal DbSet<TEntity> dbSet;
        public GenericRepositoryAsync(MemberContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public async virtual Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        public async virtual Task<TEntity> GetByIDAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }
        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await query.SingleOrDefaultAsync<TEntity>();
        }
        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return await query.FirstOrDefaultAsync<TEntity>();
        }
        public virtual async Task DeleteAsync(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            await DeleteAsync(entityToDelete);
        }
        public virtual async Task DeleteAsync(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            await Task.Yield();
        }
        public virtual async Task InsertAsync(TEntity entity)
        {
            dbSet.Add(entity);
            await Task.Yield();
        }
        public virtual async Task UpdateAsync(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            await Task.Yield();
        }
    }
}
