using Licitacija1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija1.DTOs
{
    /// <summary>
    /// klasa LicitacijaDTO
    /// </summary>
    public class LicitacijaDTO
    {

        /// <summary>
        /// Identifikator licitacije
        /// </summary>
        public Guid LicitacijaID { get; set; }
        /// <summary>
        /// Godina licitacije
        /// </summary>
        public int brojLicitacije { get; set; }
        /// <summary>
        /// Godina licitacije
        /// </summary>
        public int godina { get; set; }
        /// <summary>
        /// Ogranicenje licitacije
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
        
        public ICollection<JavnoNadmetanjeDTO> javnaNadmetanja { get; set; }

        public ICollection<DokumentModel> dokumenti { get; set; }

    }
}
