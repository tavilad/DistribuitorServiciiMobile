namespace DistribuitorServiciiMobile.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>The Abonament Entity Model</summary>
    public partial class Abonament
    {
        /// <summary>Initializes a new instance of the <see cref="Abonament" /> class.</summary>
        public Abonament()
        {
        }

        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>Gets or sets the pret.</summary>
        /// <value>The pret.</value>
        public double Pret { get; set; }

        /// <summary>Gets or sets the data inceput.</summary>
        /// <value>The data inceput.</value>
        public DateTime DataInceput { get; set; }

        /// <summary>Gets or sets the data sfarsit.</summary>
        /// <value>The data sfarsit.</value>
        public DateTime DataSfarsit { get; set; }

        /// <summary>Gets or sets the abonament minute.</summary>
        /// <value>The abonament minute.</value>
        public virtual ICollection<Minute> AbonamentMinute { get; set; }

        /// <summary>Gets or sets the abonament date.</summary>
        /// <value>The abonament date.</value>
        public virtual ICollection<DateMobile> AbonamentDate { get; set; }

        /// <summary>Gets or sets the abonament SMS.</summary>
        /// <value>The abonament SMS.</value>
        public virtual ICollection<SMS> AbonamentSms { get; set; }

        /// <summary>Gets or sets the contracte.</summary>
        /// <value>The contracte.</value>
        public virtual ICollection<Contract> Contracte { get; set; }
    }
}
