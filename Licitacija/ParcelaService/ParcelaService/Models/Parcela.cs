using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using ParcelaService.Models.Enums;

namespace ParcelaService.Models
{
    /// <summary>
    /// Predstavlja realni entitet parcele.
    /// </summary>
    public class Parcela
    {
        /// <summary>
        /// Id parcele
        /// </summary>
        [Key]
        public Guid ParcelaId { get; set; }

        /// <summary>
        /// Broj parcele
        /// </summary>
        [Required]
        public string BrojParcele { get; set; }
        /// <summary>
        /// Broj lista nepokretnosti
        /// </summary>
        [Required]
        public string BrojListaNepokretnosti { get; set; }

        /// <summary>
        /// Id katastarske opstine
        /// </summary>
        [Required]
        public Guid KatastarskaOpstinaId { get; set; }

        /// <summary>
        /// Kultura
        /// </summary>
        public Kultura Kultura { get; set; }

        /// <summary>
        /// Klasa
        /// </summary>
        public Klasa Klasa { get; set; }

        /// <summary>
        /// Obradivost
        /// </summary>
        public Obradivost Obradivost { get; set; }

        /// <summary>
        /// Strani kljuc zasticene zone
        /// </summary>
        [ForeignKey("ZasticenaZona")]
        public Guid ZasticenaZonaId { get; set; }

        /// <summary>
        /// Zasticena zona entitet
        /// </summary>
        public ZasticenaZona ZasticenaZona { get; set; }

        /// <summary>
        /// Oblik svojine
        /// </summary>
        public OblikSvojine OblikSvojine { get; set; }

        /// <summary>
        /// Odvodnjavanje
        /// </summary>
        [MaxLength(50)]
        public string Odvodnjavanje { get; set; }

        /// <summary>
        /// Stvarno stanje kulture
        /// </summary>
        [MaxLength(50)]
        public string KulturaStvarnoStanje { get; set; }

        /// <summary>
        /// Stvarno stanje klase
        /// </summary>
        [MaxLength(50)]
        public string KlasaStvarnoStanje { get; set; }

        /// <summary>
        /// Stvarno stanje obradivosti
        /// </summary>
        [MaxLength(50)]
        public string ObradivostStvarnoStanje { get; set; }

        /// <summary>
        /// Stvarno stanje zasticene zone
        /// </summary>
        [MaxLength(50)]
        public string ZasticenaZonaStvarnoStanje { get; set; }

        /// <summary>
        /// Stvarno stanje odvodnjavanja
        /// </summary>
        [MaxLength(50)]
        public string OdvodnjavanjeStvarnoStanje { get; set; }

        /// <summary>
        /// Lista delova parcele
        /// </summary>
        [NotMapped]
        public List<DeoParcele> DeloviParcele { get; set; }
    }
}
