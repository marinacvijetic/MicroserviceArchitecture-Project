using Dokument.Entities;
using System;
using System.Collections.Generic;

namespace Dokument.Data
{
    public interface IVerzijaDokumentaRepo
    {
        bool SaveChanges();

        IEnumerable<VerzijaDokumentaEntity> GetAllVerzije();
        VerzijaDokumentaEntity GetVerzijaById(Guid id);

        void CreateVerzija(VerzijaDokumentaEntity verzija);

        void DeleteVerzija(Guid VerzijaDokumentaID);

        void UpdateVerzija(VerzijaDokumentaEntity ugovor);
    }
}
