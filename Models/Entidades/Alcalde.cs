using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ProyectoFinalProg1.Models.Entidades;


namespace ProyectoFinalProg1.Models.Entidades
{
    public class Alcalde
    {
        public int Id { get; set; }  
        public string? Nombres { get; set; } 
        public string? Apellidos { get; set; } 

        [DisplayName("Inicio de alcaldia")]
        public DateTime InicioAlcaldia{ get; set; }

        public List<FormacionAcademica>? Academico { get; set; }       
        public int Aceptacion { get; set; } 

        public int MunicipalidadId{ get; set; } 
        
    }
}