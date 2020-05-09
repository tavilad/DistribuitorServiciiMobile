namespace DistribuitorServiciiMobile.Models
{
    using DomainModel.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>Client entity class</summary>
    public partial class Client
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        /// <summary>Gets or sets the last name.</summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        /// <summary>Gets or sets the cod numeric personal.</summary>
        /// <value>The cod numeric personal.</value>
        public string CodNumericPersonal { get; set; }

        /// <summary>Gets or sets the contracte.</summary>
        /// <value>The contracte.</value>
        public virtual ICollection<Contract> Contracte { get; set; }
    }
}
