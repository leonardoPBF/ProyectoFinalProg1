using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using ProyectoFinalProg1.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    public class UsuarioService
    {
        private readonly ApplicationDbContext _usuario;

        public UsuarioService(ApplicationDbContext context)
        {
            _usuario = context;
        }

        public async Task<Usuario> CuentaUsuario(string contraseña, string Email)
        {
           var usuario = await _usuario.Usuario
            .SingleOrDefaultAsync(u => u.Email == Email);

            if (usuario == null || !VerificarContraseña(contraseña, contraseñaHash: usuario.contraseña))
            {
                // El usuario con el correo electrónico dado no existe.
                return null;
            }
            
            return usuario;
        }

        private bool VerificarContraseña(string contraseña, string contraseñaHash)
        {

            return contraseñaHash == contraseña;
        }
    }
}