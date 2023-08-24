using KupacService.Entities.Enumeration;
using KupacService.Models.OvlascenoLice;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace KupacService.Models.StraniDrzavljanin
{
    /// <summary>
    /// DTO za ažuriranje ovlašćenog lica koje je strani državljanin.
    /// </summary>
    public class StraniDrzavljaninDTOUpdate : OvlascenoLiceDTOUpdate, IValidatableObject
    {
        /// <summary>
        /// Jedinstveni broj pasoša
        /// </summary>
        [Required, MaxLength(12)]
        public string BrojPasosa { get; set; }

        /// <summary>
        /// Država čiji je građanin ovlašćeno lice.
        /// </summary>
        public Drzava Drzava { get; set; }

        /// <summary>
        /// Metoda za validaciju
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public new IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!IsValidBrojPasosa(BrojPasosa))
            {
                yield return new ValidationResult(
                    "Broj pasoša može sadržati samo slova i brojeve.",
                    new[] { "StraniDrzavljaninDTOUpdate" });
            }

        }

        private static bool IsValidBrojPasosa(string BrojPasosa)
        {
            return Regex.IsMatch(BrojPasosa, @"^[a-zA-Z0-9]+$");
        }
    }
}
