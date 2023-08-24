using ParcelaService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelaService.DTOs.UpdateDto
{
    /// <summary>
    /// Predstavlja model parcele koji se koristi prilikom azuriranja podataka.
    /// </summary>
    public class ParcelaUpdateDto
    {
        /// <summary>
        /// Id parcele.
        /// </summary>
        public Guid ParcelaId { get; set; }

        /// <summary>
        /// Broj parcele.
        /// </summary>
        public string BrojParcele { get; set; }

        /// <summary>
        /// Broj lista nepokretnosti.
        /// </summary>
        public string BrojListaNepokretnosti { get; set; }

        /// <summary>
        /// Id katastarske opstine 
        /// </summary>
        public Guid KatastarskaOpstinaId { get; set; }

        /// <summary>
        /// Kultura.
        /// </summary>
        public Kultura Kultura { get; set; }

        /// <summary>
        /// Klasa.
        /// </summary>
        public Klasa Klasa { get; set; }

        /// <summary>
        /// Obradivost.
        /// </summary>
        public Obradivost Obradivost { get; set; }

        /// <summary>
        /// Id zasticene zone.
        /// </summary>
        public Guid ZasticenaZonaId { get; set; }

        /// <summary>
        /// Oblik svojine.
        /// </summary>
        public OblikSvojine OblikSvojine { get; set; }

        /// <summary>
        /// Odvodnjavanje.
        /// </summary>
        public string Odvodnjavanje { get; set; }

        /// <summary>
        /// Stvarno stanje kulture.
        /// </summary>
        public string KulturaStvarnoStanje { get; set; }

        /// <summary>
        /// Stvarno stanje klase.
        /// </summary>
        public string KlasaStvarnoStanje { get; set; }

        /// <summary>
        /// Stvarno stanje obradivosti.
        /// </summary>
        public string ObradivostStvarnoStanje { get; set; }

        /// <summary>
        /// Stvarno stanje zasticene zone.
        /// </summary>
        public string ZasticenaZonaStvarnoStanje { get; set; }

        /// <summary>
        /// Stvarno stanje odvodnjavanja.
        /// </summary>
        public string OdvodnjavanjeStvarnoStanje { get; set; }
    }
}
