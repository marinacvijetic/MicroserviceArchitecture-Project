using System;

namespace KatastarskaOpstinaService.DTOs
{
    /// <summary>
    /// Predstavlja model parcela.
    /// </summary>
    public class ParcelaDto
    {
        /// <summary>
        /// ID parcele
        /// </summary>
        public Guid ParcelaId { get; set; }
        /// <summary>
        /// Broj parcele
        /// </summary>
        public string BrojParcele { get; set; }
        /// <summary>
        /// Broj liste nepokretnosti
        /// </summary>
        public string BrojListaNepokretnosti { get; set; }
    }
}
