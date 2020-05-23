namespace DataMapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;
    using Microsoft.EntityFrameworkCore;

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public BaseRepository()
        {
        }

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task.</returns>
        public async Task Delete(int id)
        {
            await this.Delete(await this.GetById(id));
        }

        /// <summary>Deletes the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task.</returns>
        public async Task Delete(T entity)
        {
            using (DistribuitorServiciiMobileContext context = new DistribuitorServiciiMobileContext())
            {
                DbSet<T> dbSet = context.Set<T>();

                if (context.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }

                dbSet.Remove(entity);

                await context.SaveChangesAsync();
            }

        }

        /// <summary>Gets the specified filter.</summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Task.</returns>
        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            using (DistribuitorServiciiMobileContext context = new DistribuitorServiciiMobileContext())
            {
                DbSet<T> dbSet = context.Set<T>();

                IQueryable<T> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
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
        }

        /// <summary>Inserts the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task.</returns>
        public async Task Insert(T entity)
        {
            using (DistribuitorServiciiMobileContext context = new DistribuitorServiciiMobileContext())
            {
                DbSet<T> dbSet = context.Set<T>();
                await dbSet.AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>Updates the specified item.</summary>
        /// <param name="item">The item.</param>
        /// <returns>Task.</returns>
        public async Task Update(T item)
        {
            using (DistribuitorServiciiMobileContext context = new DistribuitorServiciiMobileContext())
            {
                DbSet<T> dbSet = context.Set<T>();
                dbSet.Attach(item);
                context.Entry(item).State = EntityState.Modified;

                await context.SaveChangesAsync();
            }
        }

        /// <summary>Gets the by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task.</returns>
        public async Task<T> GetById(object id)
        {
            using (DistribuitorServiciiMobileContext context = new DistribuitorServiciiMobileContext())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }
    }
}
