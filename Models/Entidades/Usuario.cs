using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProyectoFinalProg1.Models.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }  
        public string? Nombres { get; set; } 
        public string? Apellidos { get; set; } 

        [DisplayName("Correo electronico")]
        public string? Email { get; set; } 
        public string? contraseña { get; set; }
       
    }
}