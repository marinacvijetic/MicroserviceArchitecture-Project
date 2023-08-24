using Licitacija1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija1.Data
{
    public interface ILicitacijaDokumentRepository
    {
        List<DokumentModel> GetDokumenti();
        List<DokumentModel> GetDokumentByLicitacijaID(Guid LicitacijaID);
        DokumentModel GetDokumentByID(Guid dokumentID);
        void CreateLicitacijaDokument(DokumentModel dokument);
        void UpdateLicitacijaDokument(DokumentModel dokument);
        void Delete(Guid dokumentID);
        bool SaveChanges();
        
    }
}
