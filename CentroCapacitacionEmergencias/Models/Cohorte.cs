 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace CentroCapacitacionEmergencias.Models
{
    public class Cohorte
    {
        public int CohorteId { get; set; }

        [Required]
        [Display(Name = "Nombre Cohorte")]
        public string sNombreCohorte { get; set; }

        public ICollection<Participante> ICCohorteParticipantes { get; set; }

        [Required]
        [Display(Name = "Fecha Inicio")]
        public DateTime dFechaInicio { get; set; }

        [Required]
        [Display(Name = "Fecha Fin")]
        public DateTime dFechaFin { get; set; }

        [Required]
        [Display(Name = "Archivado?")]
        public bool bCohorteArchivada { get; set; }

        public ICollection<Curso> ICCohorteCursos { get; set; }
    }
}