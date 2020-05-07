namespace ServiceLayer.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;
    using FluentValidation;

    /// <summary>Validator class for the Abonament entity</summary>
    public class AbonamentValidation : AbstractValidator<Abonament>
    {
        /// <summary>The repo</summary>
        private IAbonamentRepository repo;

        /// <summary>The abonamente</summary>
        private IList<Abonament> abonamente;

        /// <summary>Initializes a new instance of the <see cref="AbonamentValidation" /> class.</summary>
        public AbonamentValidation()
        {
            RuleFor(abonament => abonament.Pret).GreaterThan(0).WithMessage("Pretul unui abonament nu poate fi negativ");

            RuleFor(abonament => abonament.DataInceput).GreaterThan(DateTime.Today).WithMessage("Data de inceput a abonamentului nu poate fi mai devreme de azi");

            RuleFor(abonament => abonament.DataSfarsit).GreaterThan(DateTime.Today).WithMessage("Data de sfarsit a abonamentului nu poate fi mai devreme de azi");
        }

        /// <summary>Checks if data de sfarsit is before data de inceput</summary>
        /// <param name="abonament">The abonament.</param>
        /// <returns>True if before, false if after</returns>
        private bool AbonamentSfarsitInainteDeInceput(Abonament abonament)
        {
            return abonament.DataSfarsit < abonament.DataInceput;
        }
    }
}
