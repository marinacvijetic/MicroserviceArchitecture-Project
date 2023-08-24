using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KupacService.Entities
{
    /// <summary>
    /// Broj Table entitet
    /// </summary>
    public class BrojTable
    {
        /// <summary>
        /// Primarni ključ broja table
        /// </summary>
        [Key]
        public Guid BrojTableID { get; set; }

        /// <summary>
        /// Broj table nadmetanja
        /// </summary>
        public int Broj { get; set; }

        /// <summary>
        /// Ovlašćeno lice za koje se vezuje broj table
        /// </summary>
        [NotMapped]
        [ForeignKey("OvlascenoLiceID")]
        public OvlascenoLice OvlascenoLice { get; set; }
    }
}
