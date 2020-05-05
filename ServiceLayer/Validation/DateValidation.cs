using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Validation
{
    class DateValidation : AbstractValidator<DateMobile>
    {
        private IDateRepository _repo;

        public IList<DateMobile> DateMobile;

        public DateValidation()
        {

        }
    }
}
