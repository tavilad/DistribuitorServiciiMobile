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
    public class SmsController
    {
        private ISmsRepository _smsRepository;
        private SmsValidation _smsValidation;

        public SmsController(ISmsRepository repository)
        {
            this._smsRepository = repository;
        }

        public async Task<IEnumerable<SMS>> GetAllSms()
        {
            return await _smsRepository.Get(Sms => Sms != null, null, "");
        }

        public async Task AddSms(SMS Sms)
        {
            this._smsValidation = new SmsValidation();
            ValidationResult results = _smsValidation.Validate(Sms);
            if (results.Errors.Count == 0)
                await _smsRepository.Insert(Sms);

        }

        public async Task DeleteSms(SMS Sms)
        {
            await _smsRepository.Delete(Sms);
        }
    }
}
