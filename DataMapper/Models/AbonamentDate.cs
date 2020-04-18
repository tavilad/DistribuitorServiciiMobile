using System;
using DistribuitorServiciiMobile.Models;

namespace DistribuitorServiciiMobile.Models
{
    public partial class AbonamentDate
    {
        public Guid Id { get; set; }
        public Guid? AbonamentId { get; set; }
        public Guid? DateId { get; set; }

        public virtual Abonament Abonament { get; set; }
        public virtual DateMobile Date { get; set; }
    }
}