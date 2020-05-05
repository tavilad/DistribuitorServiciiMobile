using DistribuitorServiciiMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DistribuitorServiciiMobile.Models
{
    public class Bonus
    {
        public Guid Id { get; set; }
        public double MinuteBonus { get; set; }
        public int SmsBonus { get; set; }
        public double DateBonus { get; set; }
        public virtual Contract Contract { get; set; } 
    }
}
