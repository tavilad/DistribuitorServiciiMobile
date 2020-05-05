using DistribuitorServiciiMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DistribuitorServiciiMobile.Models
{
    public class Contract
    {
        public Guid Id { get; set; }
        public virtual Client Client { get; set; }
        public virtual Abonament Abonament { get; set; }
    }
}
