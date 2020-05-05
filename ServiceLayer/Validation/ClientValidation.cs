using DataMapper.Interfaces;
using DistribuitorServiciiMobile.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Validation
{
    class ClientValidation : AbstractValidator<Client>
    {
        private IClientRepository _repo;
        public IList<Client> Clienti { get; set; }
        
        public ClientValidation()
        {

        }
    }
}
