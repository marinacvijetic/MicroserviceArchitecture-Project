using KupacService.Models;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KupacService.Entities
{
    public class KupacJavnoNadmetanje
    {
        public Guid KupacID { get; set; }
        public Guid? JavnoNadmetanjeID { get; set; }

        public Kupac Kupac { get; set; }
        public JavnoNadmetanjeDTO JavnoNadmetanje { get; set; }
    }
}
