namespace DistribuitorServiciiMobile.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    /// <summary>Bonus entity class</summary>
    public class Bonus
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        /// <summary>Gets or sets the minute bonus.</summary>
        /// <value>The minute bonus.</value>
        public double MinuteBonus { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        /// <summary>Gets or sets the SMS bonus.</summary>
        /// <value>The SMS bonus.</value>
        public int SmsBonus { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        /// <summary>Gets or sets the date bonus.</summary>
        /// <value>The date bonus.</value>
        public double DateBonus { get; set; }

        [Required]
        /// <summary>Gets or sets the contract.</summary>
        /// <value>The contract.</value>
        public virtual Contract Contract { get; set; } 
    }
}
