using System;
using System.Collections.Generic;

namespace DistribuitorServiciiMobile.Models
{
    public partial class DateMobile
    {
        public Guid Id { get; set; }
        public string TipDate { get; set; }
        public int NumarDate { get; set; }

        public virtual ICollection<AbonamentDate> AbonamentDate { get; set; }
    }
}