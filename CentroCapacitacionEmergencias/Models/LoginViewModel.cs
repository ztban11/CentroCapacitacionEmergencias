using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace CentroCapacitacionEmergencias.Models
{
    public class LoginViewModel
    {
        [Required]
        public string sNombreUsuario { get; set; }

        [Required]
        public string sPassword { get; set; }
    }
}