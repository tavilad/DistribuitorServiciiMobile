namespace ServiceLayer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Threading.Tasks;
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;

    /// <summary>Service layer controller for the Bonus entity</summary>
    public class BonusController
    {
        /// <summary>The bonus repository</summary>
        private IBonusRepository bonusRepository;

        private ClientController clientController;

        /// <summary>Initializes a new instance of the <see cref="BonusController" /> class.</summary>
        /// <param name="repository">The repository.</param>
        public BonusController(IBonusRepository repository, ClientController clientController)
        {
            this.bonusRepository = repository;
            this.clientController = clientController;
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
            if (bonus == null)
            {
                throw new ArgumentNullException(nameof(bonus));
            }

            this.Validate(bonus);

            if(!await this.clientController.CheckClientPaymentsOnTime(bonus.Contract.Client))
            {
                throw new ArgumentException("Clientul nu este bun platnic");
            }

            await this.bonusRepository.Insert(bonus);
        }

        /// <summary>Deletes the bonus.</summary>
        /// <param name="bonus">The bonus.</param>
        /// <returns>Awaitable task</returns>
        public async Task DeleteBonus(Bonus bonus)
        {
            if (bonus == null)
            {
                throw new ArgumentNullException(nameof(bonus));
            }

            await this.bonusRepository.Delete(bonus);
        }

        public async Task DeleteBonusByID(int id)
        {
            await this.bonusRepository.Delete(id);
        }

        public async Task UpdateBonus(Bonus bonus)
        {
            if (bonus == null)
            {
                throw new ArgumentNullException(nameof(bonus));
            }

            await this.bonusRepository.Update(bonus);
        }

        public async Task<Bonus> GetById(object id)
        {
            return await this.bonusRepository.GetById(id);
        }

        private void Validate(Bonus bonus)
        {
            var context = new ValidationContext(bonus);
            Validator.ValidateObject(bonus, context, true);
        }
    }
}
