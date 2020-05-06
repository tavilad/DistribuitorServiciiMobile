using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        /// <summary>The context</summary>
        private readonly DistribuitorServiciiMobileContext _context;

        /// <summary>Initializes a new instance of the <see cref="BaseRepository{T}" /> class.</summary>
        /// <param name="context">The context.</param>
        public BaseRepository(DistribuitorServiciiMobileContext context)
        {
            this._context = context;
        }

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        public async Task Delete(int id)
        {
            await Delete(await GetByID(id));
        }

        /// <summary>Deletes the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        public async Task Delete(T entity)
        {
            var dbSet = this._context.Set<T>();

            if (this._context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);

            await this._context.SaveChangesAsync();
        }

        /// <summary>Gets the specified filter.</summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            var dbSet = this._context.Set<T>();

            IQueryable<T> query = dbSet;

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

        /// <summary>Inserts the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        public async Task Insert(T entity)
        {
            var dbSet = this._context.Set<T>();
            await dbSet.AddAsync(entity);
            await this._context.SaveChangesAsync();
        }

        /// <summary>Updates the specified item.</summary>
        /// <param name="item">The item.</param>
        public async Task Update(T item)
        {
            var dbSet = this._context.Set<T>();
            dbSet.Attach(item);
            this._context.Entry(item).State = EntityState.Modified;

            await this._context.SaveChangesAsync();
        }

        /// <summary>Gets the by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<T> GetByID(object id)
        {
            return await this._context.Set<T>().FindAsync(id);
        }
    }
}
