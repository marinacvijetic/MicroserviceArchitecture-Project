using System;
using System.ComponentModel.DataAnnotations;

namespace KupacService.Entities
{
    /// <summary>
    /// Potvrda Broja table
    /// </summary>
    public class BrojTableConfirmation
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid BrojTableID { get; set; }

        /// <summary>
        /// Broj
        /// </summary>
        public int Broj { get; set; }
    }
}
