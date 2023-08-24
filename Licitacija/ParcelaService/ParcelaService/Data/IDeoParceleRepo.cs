using ParcelaService.Models;
using System.Collections.Generic;
using System;
using ParcelaService.Entities.Confirmations;

namespace ParcelaService.Data
{
    public interface IDeoParceleRepo
    {
        IEnumerable<DeoParcele> GetAll(Guid? parcelaId);
        DeoParcele GetById(Guid deoParceleId);
        void Create(DeoParcele deoParcele);
        void Update(DeoParcele deoParcele);
        void Delete(Guid deoParceleId);
        bool SaveChanges();


    }
}
