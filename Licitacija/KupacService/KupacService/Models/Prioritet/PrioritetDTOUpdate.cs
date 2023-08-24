using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KupacService.Models.Prioritet
{
    /// <summary>
    /// DTO za ažuriranje prioriteta.
    /// </summary>
    public class PrioritetDTOUpdate : IValidatableObject
    {
        /// <summary>
        /// Identifikaciona oznaka prioriteta.
        /// </summary>
        public int PrioritetID { get; set; }

        /// <summary>
        /// Razlog zbog kog je kupac prioritet.
        /// </summary>
        [Required]
        public string PrioritetIzbor { get; set; }

        /// <summary>
        /// Metoda za validaciju
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new System.NotImplementedException();
        }
    }
}
