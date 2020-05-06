namespace DistribuitorServiciiMobile.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>SMS entity class</summary>
    public partial class SMS
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the tip SMS.</summary>
        /// <value>The tip SMS.</value>
        public string TipSms { get; set; }

        /// <summary>Gets or sets the numar SMS.</summary>
        /// <value>The numar SMS.</value>
        public int NumarSms { get; set; }
    }
}