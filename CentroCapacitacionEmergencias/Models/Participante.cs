using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace CentroCapacitacionEmergencias.Models
{
    public class Participante
    {
        public int ParticipanteId { get; set; } // Participante ID Interno

        [Display(Name = "Tipo Identificación")]
        public string sTipoIdentificacion { get; set; }

        [Display(Name = "Número de Identificación")]
        public string sNumeroIdentificacion { get; set; }

        [Display(Name = "Nombre")]
        public string sNombreCompleto { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha nacimiento")]
        public DateTime dtFechaNacimiento { get; set; }

        /* Residencia Participante */

        [Display(Name = "Provincia")]
        public string sProvincia { get; set; }

        [Display(Name = "Cantón")]
        public string sCanton { get; set; }

        [Display(Name = "Distrito")]
        public string sDistrito { get; set; }

        [Display(Name = "Detalles residencia")]
        public string sDetallesResidencia { get; set; }

        [Display(Name = "Estado civil")]
        public string sEstadoCivil { get; set; }

        [Display(Name = "E-mail")]
        public string sEmail { get; set; }

        [Display(Name = "Teléfono")]
        public string sTelefono { get; set; }

        [Display(Name = "Dirección residencia")]
        public string sDireccionResidencia { get; set; }

        [Display(Name = "Contacto emergencia")]
        public string sContactoEmergencia { get; set; }

        public bool bEstaActivo { get; set; } = true;

        public ICollection<ParticipanteCurso> ICCursosParticipante { get; set; }

        public int iIDCohorte { get; set; }
        public Cohorte Cohorte { get; set; }
    }
}