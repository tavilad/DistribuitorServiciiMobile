namespace DistribuitorServiciiMobile.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>Contract entity class</summary>
    public class Contract
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the client.</summary>
        /// <value>The client.</value>
        public virtual Client Client { get; set; }

        /// <summary>Gets or sets the abonament.</summary>
        /// <value>The abonament.</value>
        public virtual Abonament Abonament { get; set; }
    }
}
