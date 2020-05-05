using System;
using System.Collections.Generic;

namespace DistribuitorServiciiMobile.Models
{
    public partial class Client
    {
        public Client()
        {
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CodNumericPersonal { get; set; }
        public virtual ICollection<Contract> Contracte { get; set; }
    }
}
