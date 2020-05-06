using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Validation
{
    class AbonamentValidation : AbstractValidator<Abonament>
    {
        private IAbonamentRepository _repo;

        public IList<Abonament> Abonamente;

        public AbonamentValidation()
        {
            RuleFor(abonament => abonament.Pret).GreaterThan(0).
                WithMessage("Pretul unui abonament nu poate fi negativ");

            RuleFor(abonament => abonament.DataInceput).GreaterThan(DateTime.Today).
                WithMessage("Data de inceput a abonamentului nu poate fi mai devreme de azi");

            RuleFor(abonament => abonament.DataSfarsit).GreaterThan(DateTime.Today).
                WithMessage("Data de sfarsit a abonamentului nu poate fi mai devreme de azi");
        }

        private bool AbonamentSfarsitInainteDeInceput(Abonament abonament)
        {
            return abonament.DataSfarsit < abonament.DataInceput;
        }
    }
}
