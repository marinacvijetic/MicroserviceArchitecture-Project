using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UplataService.Auth
{
    public interface IAuthHelper
    {
        public bool Authorize(string key);
    }
}
