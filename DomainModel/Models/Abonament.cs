namespace DistribuitorServiciiMobile.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>The Abonament Entity Model</summary>
    public partial class Abonament
    {

        /// <summary>
        /// The auction end
        /// </summary>
        private DateTime _abonamentEnd = DateTime.MaxValue;

        /// <summary>
        /// The auction start
        /// </summary>
        private DateTime _abonamentStart = DateTime.Now;

        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        /// <summary>Gets or sets the pret.</summary>
        /// <value>The pret.</value>
        public double Pret { get; set; }

        [Required]
        /// <summary>Gets or sets the data inceput.</summary>
        /// <value>The data inceput.</value>
        public DateTime DataInceput
        {
            get => this._abonamentStart;
            set
            {
                if (value >= this._abonamentEnd)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Data de inceput a abonamentului nu poate fi dupa data de sfarsit");
                }

                if (value < DateTime.Now)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Data de inceput a abonamentului nu poate fi in trecut");
                }

                this._abonamentStart = value;
            }
        }

        [Required]
        /// <summary>Gets or sets the data sfarsit.</summary>
        /// <value>The data sfarsit.</value>
        public DateTime DataSfarsit {
            get => this._abonamentEnd;
            set
            {
                if (value <= this._abonamentStart)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Data de sfarsit nu poate fi inainte de data de inceput");
                }

                this._abonamentEnd = value;
            }
        }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string NumeAbonament { get; set; }

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
