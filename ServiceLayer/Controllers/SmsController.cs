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

    /// <summary>Service layer controller for the SMS entity</summary>
    public class SmsController
    {
        /// <summary>The SMS repository</summary>
        private ISmsRepository smsRepository;

        /// <summary>The SMS validation</summary>
        private SmsValidation smsValidation;

        /// <summary>Initializes a new instance of the <see cref="SmsController" /> class.</summary>
        /// <param name="repository">The repository.</param>
        public SmsController(ISmsRepository repository)
        {
            this.smsRepository = repository;
        }

        /// <summary>Gets all SMS.</summary>
        /// <returns>A list of SMS entity</returns>
        public async Task<IEnumerable<SMS>> GetAllSms()
        {
            return await this.smsRepository.Get(Sms => Sms != null, null, string.Empty);
        }

        /// <summary>Adds the SMS.</summary>
        /// <param name="sms">The SMS.</param>
        /// <returns>Awaitable task</returns>
        public async Task AddSms(SMS sms)
        {
            this.smsValidation = new SmsValidation();
            ValidationResult results = this.smsValidation.Validate(sms);
            if (results.Errors.Count == 0)
            {
                await this.smsRepository.Insert(sms);
            }
        }

        /// <summary>Deletes the SMS.</summary>
        /// <param name="sms">The SMS.</param>
        /// <returns>Awaitable task</returns>
        public async Task DeleteSms(SMS sms)
        {
            await this.smsRepository.Delete(sms);
        }
    }
}
