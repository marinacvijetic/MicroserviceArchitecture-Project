using ParcelaService.Entities.Confirmations;
using ParcelaService.Models;
using System.Collections.Generic;
using System;

namespace ParcelaService.Data
{
    public interface IKvalitetZemljistaRepo
    {
        IEnumerable<KvalitetZemljista> GetAll();
        KvalitetZemljista GetById(Guid kvalitetZemljistaId);
        void Create(KvalitetZemljista kvalitetZemljista);
        void Update(KvalitetZemljista kvalitetZemljista);
        void Delete(Guid kvalitetZemljistaId);
        bool SaveChanges();
    }
}
