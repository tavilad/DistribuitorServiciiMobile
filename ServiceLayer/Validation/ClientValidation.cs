namespace ServiceLayer.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using DataMapper.Interfaces;
    using DistribuitorServiciiMobile.Models;
    using FluentValidation;

    /// <summary>Validator class for the Client entity</summary>
    public class ClientValidation : AbstractValidator<Client>
    {
        /// <summary>The repo</summary>
        private IClientRepository repo;

        /// <summary>Gets or sets the clienti.</summary>
        /// <value>The clienti.</value>
        private IList<Client> clienti;

        /// <summary>Initializes a new instance of the <see cref="ClientValidation" /> class.</summary>
        public ClientValidation()
        {
        }
    }
}
