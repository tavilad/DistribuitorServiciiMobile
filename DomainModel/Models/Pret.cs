using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DomainModel.Models
{
    public class Pret
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Valuta { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double Suma { get; set; }
    }
}
