using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProyectoFinalProg1.Models.Entidades
{
    public class Municipalidad
    {
        
        public int Id { get; set; }  

        [DisplayName("Nombre de la municipalidad")]
        public string? NombreMunicipalidad { get; set; } 
        public string? Departamento { get; set; } 
        public string? Provincia { get; set; } 
        public string? Distrito { get; set; } 
        public string? Direccion { get; set; }
        public string? Referencia { get; set; } 
        public int Aceptacion { get; set; }  
        public Alcalde? Alcalde { get; set; }  
        

    }
}