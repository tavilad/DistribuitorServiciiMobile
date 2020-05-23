namespace ServiceLayer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;
    using FluentValidation.Results;

    /// <summary>Service layer controller for the Abonament entity</summary>
    public class AbonamentController
    {
        /// <summary>The abonament repository</summary>
        private IAbonamentRepository abonamentRepository;

        /// <summary>Initializes a new instance of the <see cref="AbonamentController" /> class.</summary>
        /// <param name="repository">The repository.</param>
        public AbonamentController(IAbonamentRepository repository)
        {
            this.abonamentRepository = repository;
        }

        /// <summary>Gets all abonament.</summary>
        /// <returns>A list of Abonament entities</returns>
        public async Task<IEnumerable<Abonament>> GetAllAbonament()
        {
            return await this.abonamentRepository.Get(abonament => abonament != null, null, string.Empty);
        }

        /// <summary>Adds the abonament.</summary>
        /// <param name="abonament">The abonament.</param>
        /// <returns>Awaitable task</returns>
        public async Task AddAbonament(Abonament abonament)
        {
            if (abonament == null)
            {
                throw new ArgumentNullException(nameof(abonament));
            }

            await this.abonamentRepository.Insert(abonament);
        }

        /// <summary>Deletes the abonament.</summary>
        /// <param name="abonament">The abonament.</param>
        /// <returns>Awaitable task</returns>
        public async Task DeleteAbonament(Abonament abonament)
        {
            if (abonament == null)
            {
                throw new ArgumentNullException(nameof(abonament));
            }

            await this.abonamentRepository.Delete(abonament);
        }

        public async Task DeleteAbonamentByID(int id)
        {
            await this.abonamentRepository.Delete(id);
        }

        public async Task UpdateAbonament(Abonament abonament)
        {
            if (abonament == null)
            {
                throw new ArgumentNullException(nameof(abonament));
            }

            await this.abonamentRepository.Update(abonament);
        }

        public async Task<Abonament> GetById(object id)
        {
            return await this.abonamentRepository.GetById(id);
        }
    }
}
