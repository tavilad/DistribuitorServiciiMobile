using System;
using System.Collections.Generic;

namespace DistribuitorServiciiMobile.Models
{
    public partial class Client
    {
        public Client()
        {
            Abonament = new HashSet<Abonament>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CodNumericPersonal { get; set; }

        public virtual ICollection<Abonament> Abonament { get; set; }
    }
}
