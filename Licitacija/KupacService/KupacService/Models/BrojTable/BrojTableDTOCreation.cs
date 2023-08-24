using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KupacService.Models.BrojTable
{
    /// <summary>
    /// DTO za kreiranje broja table.
    /// </summary>
    public class BrojTableDTOCreation : IValidatableObject
    {
        /// <summary>
        /// Broj table.
        /// </summary>
        public int Broj { get; set; }

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
