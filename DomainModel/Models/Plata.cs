using DistribuitorServiciiMobile.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel.Models
{
    public class Plata
    {
        public Guid Id { get; set; }

        [Required]
        public Client Client { get; set; }

        [Required]
        public DateTime DataPlata { get; set; }

        [Required]
        public Contract Contract { get; set; }

        [Required]
        public virtual Pret TotalDePlata { get; set; }

        [Required]
        public virtual Pret SumaPlatita { get; set; }

        [Required]
        public DateTime DataScadenta { get; set; }

        public bool EsteAchitat
        {
            get
            {
                return DataPlata <= DataScadenta && TotalDePlata.Suma == SumaPlatita.Suma;
            }
        }  
    }
}
