namespace DistribuitorServiciiMobile.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>Minute entity class</summary>
    public partial class Minute
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the tip minute.</summary>
        /// <value>The tip minute.</value>
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string TipMinute { get; set; }

        /// <summary>Gets or sets the numar minute.</summary>
        /// <value>The numar minute.</value>
        [Required]
        [Range(0, int.MaxValue)]
        public int NumarMinute { get; set; }
    }
}
