using Licitacija1.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licitacija1.SyncDataServices.Http
{
    public interface IJavnoNadmetanjeDataClient
    {
        Task<List<JavnoNadmetanjeDTO>> GetJavnaNadmetanjaByLicitacijaID();
    }
}
