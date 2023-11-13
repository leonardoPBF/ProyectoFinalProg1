using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using ProyectoFinalProg1.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    public class municipalidadService
    {
        private readonly ApplicationDbContext _municipalidad;

        public municipalidadService(ApplicationDbContext context)
        {
            _municipalidad = context;
        }

        public async Task<List<Municipalidad>> FiltrarEntidadesPorElementoAsync(string Provincia)
        {
            // Utilizando Where para filtrar las entidades basadas en una condición
            return await _municipalidad.Municipalidad
                .Where(e => e.Provincia.Contains(Provincia))
                .ToListAsync();
        }
    }
}