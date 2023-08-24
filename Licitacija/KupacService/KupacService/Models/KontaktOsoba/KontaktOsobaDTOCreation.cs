using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KupacService.Models.KontaktOsoba
{
    /// <summary>
    /// DTO za kreiranje kontakt osobe.
    /// </summary>
    public class KontaktOsobaDTOCreation : IValidatableObject
    {

        /// <summary>
        /// Ime osobe.
        /// </summary>
        [MaxLength(20)]
        public string Ime { get; set; }

        /// <summary>
        /// Prezime osobe.
        /// </summary>
        [MaxLength(20)]
        public string Prezime { get; set; }

        /// <summary>
        /// Funkcija koju osoba vrši.
        /// </summary>
        public string Funkcija { get; set; }

        /// <summary>
        /// Kontakt telefon osobe.
        /// </summary>
        public string Telefon { get; set; }

        /// <summary>
        /// Metoda za validaciju
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Ime == Prezime)
            {
                yield return new ValidationResult(
                    "Osoba ne može da ima istu vrednost za ime i prezime.",
                    new[] { "KontaktOsobaDTOCreation" });
            }
        }
    }
}
