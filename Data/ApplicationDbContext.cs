using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalProg1.Models.Entidades;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoFinalProg1.Models.Entidades.Municipalidad> Municipalidad { get; set; } = default!;

        public DbSet<ProyectoFinalProg1.Models.Entidades.Noticias> Noticias { get; set; } = default!;

        public DbSet<ProyectoFinalProg1.Models.Entidades.Alcalde> Alcalde { get; set; } = default!;

        public DbSet<ProyectoFinalProg1.Models.Entidades.FormacionAcademica> FormacionAcademica { get; set; } = default!;
    }
}
