using System.Globalization;
using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace ProyectoFinalProg1.Models.Entidades
{
    public class FormacionAcademica
    {
        public int Id { get; set; } 
        public string? Universidad { get; set; }  
        public string? Carrera{ get; set; }   
        [DisplayName("Año de titulación")] 
        public DateTime AñoGraduacion { get; set; }   
        public int IdAlcalde { get; set; }   
    } 
}