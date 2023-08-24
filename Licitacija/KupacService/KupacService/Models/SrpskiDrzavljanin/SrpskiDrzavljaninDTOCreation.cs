using KupacService.Models.OvlascenoLice;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KupacService.Models.SrpskiDrzavljanin
{
    /// <summary>
    /// DTO za kreiranje ovlašćenog lica koje je srpski državljanin.
    /// </summary>
    public class SrpskiDrzavljaninDTOCreation : OvlascenoLiceDTOCreation, IValidatableObject
    {
        /// <summary>
        /// Jedinstveni matični broj građanina Srbije.
        /// </summary>
        [Required,MaxLength(13)]
        public string JMBG { get; set; }

        /// <summary>
        /// Metoda za validaciju
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public new IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(JMBG, @"^\d+$"))
            {
                yield return new ValidationResult(
                    "Za vrednost polja JMBG nije dozvoljen unos karaktera koji nisu brojevi.",
                    new[] { "SrpskiDrzavljaninDTOCreation" });
            }

        }
    }
}
