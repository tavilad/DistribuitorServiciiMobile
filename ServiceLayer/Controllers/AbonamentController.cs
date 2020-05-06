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
    public class AbonamentController
    {
        private IAbonamentRepository _abonamentRepository;
        private AbonamentValidation _abonamentValidation;

        public AbonamentController(IAbonamentRepository repository)
        {
            this._abonamentRepository = repository;
        }

        public async Task<IEnumerable<Abonament>> GetAllAbonament()
        {
            return await _abonamentRepository.Get(abonament => abonament != null, null, "");
        }

        public async Task AddAbonament(Abonament abonament)
        {
            this._abonamentValidation = new AbonamentValidation();
            ValidationResult results = _abonamentValidation.Validate(abonament);
            if (results.Errors.Count == 0)
                await _abonamentRepository.Insert(abonament);

        }

        public async Task DeleteAbonament(Abonament abonament)
        {
            await _abonamentRepository.Delete(abonament);
        }
    }
}
