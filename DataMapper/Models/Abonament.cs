using System;
using System.Collections.Generic;

namespace DistribuitorServiciiMobile.Models
{
    public partial class Abonament
    {
        public Abonament()
        {
            AbonamentMinute = new HashSet<AbonamentMinute>();
        }

        public Guid Id { get; set; }
        public double Pret { get; set; }
        public Guid? ClientId { get; set; }
        public double TraficDate { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<AbonamentMinute> AbonamentMinute { get; set; }
        public virtual ICollection<AbonamentDate> AbonamentDate { get; set; }
        public virtual ICollection<AbonamentSms> AbonamentSms { get; set; }
    }
}
