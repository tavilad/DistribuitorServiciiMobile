using System;
using System.Collections.Generic;

namespace DistribuitorServiciiMobile.Models
{
    public partial class Minute
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the tip minute.</summary>
        /// <value>The tip minute.</value>
        public string TipMinute { get; set; }

        /// <summary>Gets or sets the numar minute.</summary>
        /// <value>The numar minute.</value>
        public int NumarMinute { get; set; }
    }
}
