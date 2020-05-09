namespace DistribuitorServiciiMobile.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>SMS entity class</summary>
    public partial class SMS
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        /// <summary>Gets or sets the tip SMS.</summary>
        /// <value>The tip SMS.</value>
        public string TipSms { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        /// <summary>Gets or sets the numar SMS.</summary>
        /// <value>The numar SMS.</value>
        public int NumarSms { get; set; }
    }
}