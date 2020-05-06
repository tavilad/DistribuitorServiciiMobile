using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using FluentValidation.Results;
using ServiceLayer.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Controllers
{
    public class BonusController
    {
        private IBonusRepository _bonusRepository;
        private BonusValidation _bonusValidation;

        public BonusController(IBonusRepository repository)
        {
            this._bonusRepository = repository;
        }

        public async Task<IEnumerable<Bonus>> GetAllBonus()
        {
            return await _bonusRepository.Get(bonus => bonus != null, null, "");
        }

        public async Task AddBonus(Bonus bonus)
        {
            this._bonusValidation = new BonusValidation();
            ValidationResult results = _bonusValidation.Validate(bonus);
            if (results.Errors.Count == 0)
                await _bonusRepository.Insert(bonus);

        }

        public async Task DeleteBonus(Bonus bonus)
        {
            await _bonusRepository.Delete(bonus);
        }
    }
}
