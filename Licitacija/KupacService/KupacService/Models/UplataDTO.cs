using KupacService.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KupacService.Models
{
    /// <summary>
    /// Uplata DTO
    /// </summary>
    public class UplataDTO
    {

        /// <summary>
        /// ID Uplate kupca.
        /// </summary>
        [Key]
        public Guid UplataID { get; set; }

        /// <summary>
        /// Id Kupca za uplate
        /// </summary>
        public Guid KupacID { get; set; }
        /// <summary>
        /// Navigaton property
        /// </summary>
        public Entities.Kupac Kupac { get; set; }

    }
}
