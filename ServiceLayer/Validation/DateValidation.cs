namespace ServiceLayer.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;
    using FluentValidation;

    /// <summary>Validator class for the DateMobile entity</summary>
    public class DateValidation : AbstractValidator<DateMobile>
    {
        /// <summary>The repo</summary>
        private IDateRepository repo;

        /// <summary>The date mobile</summary>
        private IList<DateMobile> dateMobile;

        /// <summary>Initializes a new instance of the <see cref="DateValidation" /> class.</summary>
        public DateValidation()
        {
        }
    }
}
