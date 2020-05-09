﻿using DistribuitorServiciiMobile.Models;
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
        [Range(0, double.MaxValue)]
        public double TotalDePlata { get; set; }
    }
}
