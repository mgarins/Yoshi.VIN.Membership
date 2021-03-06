﻿using Microsoft.EntityFrameworkCore;
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
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>,
                                                IGenericRepositoryAsync<TEntity> where TEntity : class
    {
        internal MemberContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(MemberContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
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
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query.ToList();
        }
        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query.FirstOrDefault();
        }

        public virtual async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
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
        public virtual Task<TEntity> GetByIDAsync(object id)
        {
            return dbSet.FindAsync(id);
        }
        public virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query.SingleOrDefaultAsync<TEntity>();
        }
        public virtual Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query.FirstOrDefaultAsync<TEntity>();
        }
    }
}
