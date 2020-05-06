namespace ServiceLayer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;
    using FluentValidation.Results;
    using ServiceLayer.Validation;

    /// <summary>Service layer controller for the Bonus entity</summary>
    public class BonusController
    {
        /// <summary>The bonus repository</summary>
        private IBonusRepository bonusRepository;

        /// <summary>The bonus validation</summary>
        private BonusValidation bonusValidation;

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
            this.bonusValidation = new BonusValidation();
            ValidationResult results = this.bonusValidation.Validate(bonus);
            if (results.Errors.Count == 0)
            {
                await this.bonusRepository.Insert(bonus);
            }
        }

        /// <summary>Deletes the bonus.</summary>
        /// <param name="bonus">The bonus.</param>
        /// <returns>Awaitable task</returns>
        public async Task DeleteBonus(Bonus bonus)
        {
            await this.bonusRepository.Delete(bonus);
        }
    }
}
