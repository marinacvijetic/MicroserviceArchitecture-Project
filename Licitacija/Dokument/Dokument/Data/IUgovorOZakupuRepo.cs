
using Dokument.Entities;
using System;
using System.Collections.Generic;

namespace Dokument.Data
{
    public interface IUgovorOZakupuRepo
    {

        bool SaveChanges();

        IEnumerable<UgovorOZakupuEntity> GetAllUgovori();
        UgovorOZakupuEntity GetUgovorById(Guid id);

        void CreateUgovor(UgovorOZakupuEntity ugovor);
        
        void DeleteUgovor(Guid UgovorOZakupuID);

        void UpdateUgovor(UgovorOZakupuEntity ugovor);
    }
}
