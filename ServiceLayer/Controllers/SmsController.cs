namespace ServiceLayer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;
    using FluentValidation.Results;

    /// <summary>Service layer controller for the SMS entity</summary>
    public class SmsController
    {
        /// <summary>The SMS repository</summary>
        private ISmsRepository smsRepository;

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
            await this.smsRepository.Insert(sms);
        }

        /// <summary>Deletes the SMS.</summary>
        /// <param name="sms">The SMS.</param>
        /// <returns>Awaitable task</returns>
        public async Task DeleteSms(SMS sms)
        {
            await this.smsRepository.Delete(sms);
        }

        public async Task DeleteSMSByID(int id)
        {
            await this.smsRepository.Delete(id);
        }

        public async Task UpdateSms(SMS sms)
        {
            await this.smsRepository.Update(sms);
        }
    }
}
