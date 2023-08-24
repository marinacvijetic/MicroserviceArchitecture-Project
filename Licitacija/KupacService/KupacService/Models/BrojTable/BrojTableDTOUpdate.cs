using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KupacService.Models.BrojTable
{
    /// <summary>
    /// DTO za ažuriranje broja table.
    /// </summary>
    public class BrojTableDTOUpdate : IValidatableObject
    {
        /// <summary>
        /// ID broja table
        /// </summary>
        public Guid BrojTableID { get; set; }

        /// <summary>
        /// Broj
        /// </summary>
        public int Broj { get; set; }

        /// <summary>
        /// Metoda za validaciju vrednosti. 
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Broj < 0)
            {
                yield return new ValidationResult(
                    "Broj table ne može biti manji od 0.",
                    new[] { "BrojTableDTOCreation" });
            }
        }
    }
}
