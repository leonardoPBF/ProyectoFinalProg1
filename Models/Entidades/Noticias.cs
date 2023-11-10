using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProyectoFinalProg1.Models.Entidades
{
    public class Noticias
    {
        public Guid Id { get; set; } 
        public string? Titulo { get; set; } 
        public string? Resumen { get; set; } 
        public DateTime Fecha{ get; set; } 
    }
}