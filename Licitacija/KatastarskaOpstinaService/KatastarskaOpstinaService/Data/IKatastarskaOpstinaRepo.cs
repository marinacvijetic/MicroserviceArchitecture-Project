using KatastarskaOpstinaService.Models;
using System.Collections.Generic;
using System;

namespace KatastarskaOpstinaService.Data
{
    public interface IKatastarskaOpstinaRepo
    {
        IEnumerable<KatastarskaOpstina> GetAll();
        KatastarskaOpstina GetById(Guid katastarskaOpstinaId);

        void Create(KatastarskaOpstina katastarskaOpstina);

        void Update(KatastarskaOpstina katastarskaOpstina);

        void Delete(Guid katastarskaOpstinaId);

        bool SaveChanges();
    }
}
