using System;
using System.Collections.Generic;

namespace DistribuitorServiciiMobile.Models
{
    public partial class Abonament
    {
        public Abonament()
        {
        }

        public Guid Id { get; set; }
        public double Pret { get; set; }
        public double TraficDate { get; set; }
        public DateTime DataInceput { get; set; }
        public DateTime DataSfarsit { get; set; }
        public virtual ICollection<Minute> AbonamentMinute { get; set; }
        public virtual ICollection<DateMobile> AbonamentDate { get; set; }
        public virtual ICollection<SMS> AbonamentSms { get; set; }
        public virtual ICollection<Contract> Contracte { get; set; }
    }
}
