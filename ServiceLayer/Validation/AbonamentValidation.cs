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
            RuleFor(abonament => abonament.Pret).LessThan(0).
                WithMessage("Pretul unui abonament nu poate fi negativ");

            RuleFor(abonament => abonament.DataInceput).LessThan(DateTime.Today).
                WithMessage("Data de inceput a abonamentului nu poate fi mai devreme de azi");

            RuleFor(abonament => abonament.DataSfarsit).LessThan(DateTime.Today).
                WithMessage("Data de sfarsit a abonamentului nu poate fi mai devreme de azi");
        }

        private bool AbonamentSfarsitInainteDeInceput(Abonament abonament)
        {
            return abonament.DataSfarsit < abonament.DataInceput;
        }
    }
}
