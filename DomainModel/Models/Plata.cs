using DistribuitorServiciiMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Models
{
    public class Plata
    {
        public Guid Id { get; set; }

        public Client Client { get; set; }

        public DateTime DataPlata { get; set; }

        public Contract Contract { get; set; }

        public double TotalDePlata { get; set; }
    }
}
