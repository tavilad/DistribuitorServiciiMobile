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

    /// <summary>Service layer controller for the Minute entity</summary>
    public class MinuteController
    {
        /// <summary>The minute repository</summary>
        private IMinuteRepository minuteRepository;

        /// <summary>The minute validation</summary>
        private MinuteValidation minuteValidation;

        /// <summary>Initializes a new instance of the <see cref="MinuteController" /> class.</summary>
        /// <param name="repository">The repository.</param>
        public MinuteController(IMinuteRepository repository)
        {
            this.minuteRepository = repository;
        }

        /// <summary>Gets all minute.</summary>
        /// <returns>A list of Minute entity</returns>
        public async Task<IEnumerable<Minute>> GetAllMinute()
        {
            return await this.minuteRepository.Get(Minute => Minute != null, null, string.Empty);
        }

        /// <summary>Adds the minute.</summary>
        /// <param name="minute">The minute.</param>
        /// <returns>Awaitable task</returns>
        public async Task AddMinute(Minute minute)
        {
            this.minuteValidation = new MinuteValidation();
            ValidationResult results = this.minuteValidation.Validate(minute);
            if (results.Errors.Count == 0)
            {
                await this.minuteRepository.Insert(minute);
            }
        }

        /// <summary>Deletes the minute.</summary>
        /// <param name="minute">The minute.</param>
        /// <returns>Awaitable task</returns>
        public async Task DeleteMinute(Minute minute)
        {
            await this.minuteRepository.Delete(minute);
        }
    }
}
