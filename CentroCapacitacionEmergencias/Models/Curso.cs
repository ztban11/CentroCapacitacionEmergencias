using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CentroCapacitacionEmergencias.Models
{
    public class Curso
    {
        public int CursoId { get; set; }

        [Required]
        [Display(Name = "Codigo Curso")]
        public string sCodigoCurso { get; set; }

        [Required]
        [Display(Name = "Nombre Curso")]
        public string sNombreCurso { get; set; }

        [Required]
        [Display(Name = "Activo?")]
        public bool bCursoActivo { get; set; }

        [Required]
        [Display(Name = "Puntaje Minimo")]
        public int PuntajeMinimoAprobacion { get; set; }

        [Required]
        [Display(Name = "Horas Practica")]
        public int iHorasPracticas { get; set; }

        public ICollection<ParticipanteCurso> ICCursoParticipantes { get; set; }

        public ICollection<Usuario> ICCursoInstructores { get; set; }

        public ICollection<Cohorte> ICCursoCohortes { get; set; }
    }
}