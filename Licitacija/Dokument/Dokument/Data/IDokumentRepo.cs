using Dokument.Entities;
using System.Collections.Generic;

namespace Dokument.Data
{
    public interface IDokumentRepo
    {
        bool SaveChanges();

        IEnumerable<DokumentEntity> GetAllDokumenti();
        DokumentEntity GetDokumentById(int id);

        void CreateDokument(DokumentEntity dokument);
        //dodala
        void DeleteDokument(int DokumentID);

        void UpdateDokument(DokumentEntity dokument);
    }
}
