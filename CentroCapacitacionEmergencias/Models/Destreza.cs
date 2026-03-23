using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroCapacitacionEmergencias.Models
{
    public class Destreza
    {
        public int DestrezaID { get; set; }

        public string NombreDestreza { get; set; }

        public int CursoId { get; set; }
    }
}