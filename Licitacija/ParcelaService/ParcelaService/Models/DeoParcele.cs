using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace ParcelaService.Models
{
    /// <summary>
    /// Predstavlja realni entitet dela parcele.
    /// </summary>
    public class DeoParcele
    {
        /// <summary>
        /// Id dela parcele
        /// </summary>
        [Key]
        public Guid DeoParceleId { get; set; }

        /// <summary>
        /// Strani kljuc parcele
        /// </summary>
        [ForeignKey("Parcela")]
        public Guid ParcelaId { get; set; }

        /// <summary>
        /// Parcela entitet
        /// </summary>
        public Parcela Parcela { get; set; }

        /// <summary>
        /// Redni broj dela parcele
        /// </summary>
        [Required]
        public int RedniBrojDelaParcele { get; set; }

        /// <summary>
        /// Povrsina dela parcele
        /// </summary>
        [Required]
        public int PovrsinaDelaParcele { get; set; }

        /// <summary>
        /// Strani ključ kvaliteta zemljista
        /// </summary>
        [ForeignKey("KvalitetZemljista")]
        public Guid KvalitetZemljistaId { get; set; }

        /// <summary>
        /// Kvalitet zemljista entitet
        /// </summary>
        public KvalitetZemljista KvalitetZemljista { get; set; }
    }
}
