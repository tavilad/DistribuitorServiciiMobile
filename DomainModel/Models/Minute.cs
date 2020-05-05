using System;
using System.Collections.Generic;

namespace DistribuitorServiciiMobile.Models
{
    public partial class Minute
    {
        public Minute()
        {
        }

        public Guid Id { get; set; }
        public string TipMinute { get; set; }
        public int NumarMinute { get; set; }
    }
}
