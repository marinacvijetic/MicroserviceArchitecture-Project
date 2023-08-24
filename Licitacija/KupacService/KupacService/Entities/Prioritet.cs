using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KupacService.Entities
{
    /// <summary>
    /// Prioritet Entitet
    /// </summary>
    public class Prioritet
    {
        /// <summary>
        /// Prioritet ID
        /// </summary>
        [Key]
        public int PrioritetID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PrioritetIzbor { get; set; }

        /// <summary>
        /// Kupac za kog važi određeni prioritet.
        /// </summary>
        [NotMapped]
        [ForeignKey("KupacID")]
        public Kupac Kupac { get; set; }
    }
}
