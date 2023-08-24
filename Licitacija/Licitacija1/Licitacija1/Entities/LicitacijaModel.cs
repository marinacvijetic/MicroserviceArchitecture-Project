using Licitacija1.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licitacija1.Entities
{
    public class LicitacijaModel
    {
        [Key]
        /// <summary>
        /// Identifikator licitacije
        /// </summary>
        public Guid licitacijaID { get; set; }

        /// <summary>
        /// Broj licitacije
        /// </summary>
        public int brojLicitacije { get; set; }

        /// <summary>
        /// Godina licitacije
        /// </summary>
        public int godina { get; set; }

        /// <summary>
        /// Datum licitacije
        /// </summary>
        public DateTime datumLicitacije { get; set; }

        /// <summary>
        /// Ogranicenje licitacije
        /// </summary>
        public int ogranicenjeLicitacije { get; set; }

        /// <summary>
        /// Korak cene
        /// </summary>
        public int korakCene { get; set; }

        /// <summary>
        /// Rok za dostavljanje dokumenata za prijavu
        /// </summary>
        public DateTime rokZaDostavuPrijava { get; set; }

        /// <summary>
        /// Lista dokumentacije za pravna lica
        /// </summary>
        [NotMapped]
        public ICollection<DokumentModel> dokumenti { get; set; }


        /// <summary>
        /// Lista dokumentacije za fizickih lica
        /// </summary>
        //[NotMapped]
        //public ICollection<DokumentModel> dokumentFizickaLica { get; set; }


        /// <summary>
        /// Lista javnih nadmetanja licitacije
        /// </summary>
        [NotMapped]
        public ICollection<JavnoNadmetanjeDTO> javnaNadmetanja { get; set; }

    }
}
