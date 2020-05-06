namespace DistribuitorServiciiMobile.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>DateMobile entity class</summary>
    public partial class DateMobile
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the tip date.</summary>
        /// <value>The tip date.</value>
        public string TipDate { get; set; }

        /// <summary>Gets or sets the numar date.</summary>
        /// <value>The numar date.</value>
        public int NumarDate { get; set; }
    }
}