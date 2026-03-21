using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using CentroCapacitacionEmergencias.Models;

namespace CentroCapacitacionEmergencias.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Participante> setParticipantes { get; set; }

        public DbSet<Curso> setCursos { get; set; }

        public DbSet<Cohorte> setCohortes { get; set; }

        public DbSet<ParticipanteCurso> setParticipanteCursos { get; set; }
    }
}