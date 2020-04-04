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
        private readonly DistribuitorServiciiMobileContext _context;

        public BaseRepository(DistribuitorServiciiMobileContext context)
        {
            this._context = context;
        }

        public async Task Delete(int id)
        {
            await Delete(await GetByID(id));
        }

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

        public async Task Insert(T entity)
        {
            var dbSet = this._context.Set<T>();
            await dbSet.AddAsync(entity);
            await this._context.SaveChangesAsync();
        }

        public async Task Update(T item)
        {
            var dbSet = this._context.Set<T>();
            dbSet.Attach(item);
            this._context.Entry(item).State = EntityState.Modified;

            await this._context.SaveChangesAsync();
        }

        public async Task<T> GetByID(object id)
        {
            return await this._context.Set<T>().FindAsync(id);
        }
    }
}
