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
    public class DateMobileController
    {
        private IDateRepository _dateRepository;
        private DateValidation _dateValidation;

        public DateMobileController(IDateRepository repository)
        {
            this._dateRepository = repository;
        }

        public async Task<IEnumerable<DateMobile>> GetAllDate()
        {
            return await _dateRepository.Get(Date => Date != null, null, "");
        }

        public async Task AddDate(DateMobile Date)
        {
            this._dateValidation = new DateValidation();
            ValidationResult results = _dateValidation.Validate(Date);
            if (results.Errors.Count == 0)
                await _dateRepository.Insert(Date);

        }

        public async Task DeleteDate(DateMobile Date)
        {
            await _dateRepository.Delete(Date);
        }
    }
}
