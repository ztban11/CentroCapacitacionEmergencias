using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CentroCapacitacionEmergencias.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        public string sNombreCompleto { get; set; }

        public string sCorreo { get; set; }

        public string sPassword { get; set; }

        public string Rol { get; set; }
    }
}