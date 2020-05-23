namespace ServiceLayer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;
    using FluentValidation.Results;

    /// <summary>Service layer controller for the Bonus entity</summary>
    public class BonusController
    {
        /// <summary>The bonus repository</summary>
        private IBonusRepository bonusRepository;

        /// <summary>Initializes a new instance of the <see cref="BonusController" /> class.</summary>
        /// <param name="repository">The repository.</param>
        public BonusController(IBonusRepository repository)
        {
            this.bonusRepository = repository;
        }

        /// <summary>Gets all bonus.</summary>
        /// <returns>A list of Bonus entity</returns>
        public async Task<IEnumerable<Bonus>> GetAllBonus()
        {
            return await this.bonusRepository.Get(bonus => bonus != null, null, string.Empty);
        }

        /// <summary>Adds the bonus.</summary>
        /// <param name="bonus">The bonus.</param>
        /// <returns>Awaitable task</returns>
        public async Task AddBonus(Bonus bonus)
        {
            await this.bonusRepository.Insert(bonus);
        }

        /// <summary>Deletes the bonus.</summary>
        /// <param name="bonus">The bonus.</param>
        /// <returns>Awaitable task</returns>
        public async Task DeleteBonus(Bonus bonus)
        {
            await this.bonusRepository.Delete(bonus);
        }

        public async Task DeleteBonusByID(int id)
        {
            await this.bonusRepository.Delete(id);
        }

        public async Task UpdateBonus(Bonus bonus)
        {
            await this.bonusRepository.Update(bonus);
        }

        public async Task<Bonus> GetById(object id)
        {
            return await this.bonusRepository.GetById(id);
        }
    }
}
