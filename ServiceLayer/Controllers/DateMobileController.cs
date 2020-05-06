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

    /// <summary>Service layer controller for the DateMobile entity</summary>
    public class DateMobileController
    {
        /// <summary>The date repository</summary>
        private IDateRepository dateRepository;

        /// <summary>The date validation</summary>
        private DateValidation dateValidation;

        /// <summary>Initializes a new instance of the <see cref="DateMobileController" /> class.</summary>
        /// <param name="repository">The repository.</param>
        public DateMobileController(IDateRepository repository)
        {
            this.dateRepository = repository;
        }

        /// <summary>Gets all date.</summary>
        /// <returns>A list of DateMobile entity</returns>
        public async Task<IEnumerable<DateMobile>> GetAllDate()
        {
            return await this.dateRepository.Get(Date => Date != null, null, string.Empty);
        }

        /// <summary>Adds the date.</summary>
        /// <param name="date">The date.</param>
        /// <returns>Awaitable task</returns>
        public async Task AddDate(DateMobile date)
        {
            this.dateValidation = new DateValidation();
            ValidationResult results = this.dateValidation.Validate(date);
            if (results.Errors.Count == 0)
            {
                await this.dateRepository.Insert(date);
            }
        }

        /// <summary>Deletes the date.</summary>
        /// <param name="date">The date.</param>
        /// <returns>Awaitable task</returns>
        public async Task DeleteDate(DateMobile date)
        {
            await this.dateRepository.Delete(date);
        }
    }
}
