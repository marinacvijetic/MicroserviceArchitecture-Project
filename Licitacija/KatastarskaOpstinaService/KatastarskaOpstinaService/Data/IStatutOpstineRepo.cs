using KatastarskaOpstinaService.Models;
using System.Collections.Generic;
using System;

namespace KatastarskaOpstinaService.Data
{
    public interface IStatutOpstineRepo
    {
        IEnumerable<StatutOpstine> GetAll();

        StatutOpstine GetById(Guid statutOpstineId);

        void Create(StatutOpstine statutOpstine);

        void Update(StatutOpstine statutOpstine);

        void Delete(Guid statutOpstineId);

        bool SaveChanges();
    }
}
