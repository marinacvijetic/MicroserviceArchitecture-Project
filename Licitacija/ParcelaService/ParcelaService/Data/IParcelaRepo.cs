using ParcelaService.Entities.Confirmations;
using ParcelaService.Models;
using System.Collections.Generic;
using System;

namespace ParcelaService.Data
{
    public interface IParcelaRepo
    {
        IEnumerable<Parcela> GetAll(Guid? katastarskaOpstinaId);
        public IEnumerable<DeoParcele> GetDeloveParcele(Guid parcelaId);
        Parcela GetById(Guid parcelaId);
        void Create(Parcela parcela);
        void Update(Parcela parcela);
        void Delete(Guid parcelaId);
        bool SaveChanges();
    }
}
