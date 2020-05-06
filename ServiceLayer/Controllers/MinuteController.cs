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
    public class MinuteController
    {
        private IMinuteRepository _minuteRepository;
        private MinuteValidation _minuteValidation;

        public MinuteController(IMinuteRepository repository)
        {
            this._minuteRepository = repository;
        }

        public async Task<IEnumerable<Minute>> GetAllMinute()
        {
            return await _minuteRepository.Get(Minute => Minute != null, null, "");
        }

        public async Task AddMinute(Minute Minute)
        {
            this._minuteValidation = new MinuteValidation();
            ValidationResult results = _minuteValidation.Validate(Minute);
            if (results.Errors.Count == 0)
                await _minuteRepository.Insert(Minute);

        }

        public async Task DeleteMinute(Minute Minute)
        {
            await _minuteRepository.Delete(Minute);
        }
    }
}
