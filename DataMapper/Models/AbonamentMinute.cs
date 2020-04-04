using System;
using System.Collections.Generic;

namespace DistribuitorServiciiMobile.Models
{
    public partial class AbonamentMinute
    {
        public Guid Id { get; set; }
        public Guid? AbonamentId { get; set; }
        public Guid? MinuteId { get; set; }

        public virtual Abonament Abonament { get; set; }
        public virtual Minute Minute { get; set; }
    }
}
