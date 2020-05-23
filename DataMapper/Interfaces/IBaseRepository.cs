namespace DataMapper.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>Base interface for all repositories</summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T>
    {
        /// <summary>Inserts the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Awaitable task.</returns>
        Task Insert(T entity);

        /// <summary>Updates the specified item.</summary>
        /// <param name="item">The item.</param>
        /// <returns>Awaitable task.</returns>
        Task Update(T item);

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Awaitable task.</returns>
        Task Delete(int id);

        /// <summary>Deletes the specified entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Awaitable task.</returns>
        Task Delete(T entity);

        /// <summary>Gets the specified filter.</summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <returns>Awaitable task.</returns>
        Task<IEnumerable<T>> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        Task<T> GetById(object id);
    }
}
