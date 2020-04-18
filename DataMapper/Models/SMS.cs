using System;
using System.Collections.Generic;

namespace DistribuitorServiciiMobile.Models
{
    public partial class SMS
    {
        public Guid Id { get; set; }
        public string TipSms { get; set; }
        public int NumarSms { get; set; }

        public virtual ICollection<AbonamentSms> AbonamentSms { get; set; }

    }
}