using KupacService.Models.Kupac;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KupacService.Models.FizickoLice
{
    /// <summary>
    /// DTO za kreiranje kupca koji je fizičko lice.
    /// </summary>
    public class FizickoLiceDTOCreation : KupacDTOCreation, IValidatableObject
    {
        /// <summary>
        /// Ime fizičkog lica.
        /// </summary>
        [MaxLength(20)]
        public string Ime { get; set; }

        /// <summary>
        /// Prezime fizičkog lica.
        /// </summary>
        [MaxLength(20)]
        public string Prezime { get; set; }

        /// <summary>
        /// Jedinstveni matični broj građanina.
        /// </summary>
        [Required, MaxLength(13)]
        public string JMBG { get; set; }

        /// <summary>
        /// Metoda za validaciju
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public new IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Ime == Prezime)
            {
                yield return new ValidationResult(
                    "Osoba ne može da ima istu vrednost za ime i prezime.",
                    new[] { "FizickoLiceDTOCreation" });
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(JMBG, @"^\d+$"))
            {
                yield return new ValidationResult(
                    "Za vrednost polja JMBG nije dozvoljen unos karaktera koji nisu brojevi.",
                    new[] { "FizickoLiceDTOCreation" });
            }

        }
    }
}
