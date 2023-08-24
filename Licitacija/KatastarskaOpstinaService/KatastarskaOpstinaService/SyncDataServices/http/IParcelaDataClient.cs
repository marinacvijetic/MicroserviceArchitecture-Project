using KatastarskaOpstinaService.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatastarskaOpstinaService.SyncDataServices.http
{
    public interface IParcelaDataClient
    {
        Task<List<ParcelaDto>> GetParcelaForKatastarskaOpstina(Guid katastarskaOpstinaId);
    }
}
