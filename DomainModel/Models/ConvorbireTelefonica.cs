namespace DomainModel.Models
{
    using DistribuitorServiciiMobile.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    /// <summary>Convorbire telefonica entity</summary>
    public class ConvorbireTelefonica
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        [Required]
        /// <summary>Gets or sets the initiator.</summary>
        /// <value>The initiator.</value>
        public Client Initiator { get; set; }

        [Required]
        /// <summary>Gets or sets the receptor.</summary>
        /// <value>The receptor.</value>
        public Client Receptor { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        /// <summary>Gets or sets the durata convorbire.</summary>
        /// <value>The durata convorbire.</value>
        public double DurataConvorbire { get; set; }

        [Required]
        /// <summary>Gets or sets the data apel.</summary>
        /// <value>The data apel.</value>
        public DateTime DataApel { get; set; }

        [Required]
        public string TipConvorbire { get; set; }
    }
}
