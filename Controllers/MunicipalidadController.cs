using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using ProyectoFinalProg1.Models.Entidades;

namespace ProyectoFinalProg1.Controllers
{
    public class MunicipalidadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MunicipalidadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Municipalidad
        public async Task<IActionResult> Index()
        {
              return _context.Municipalidad != null ? 
                          View(await _context.Municipalidad.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Municipalidad'  is null.");
        }

        // GET: Municipalidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Municipalidad == null)
            {
                return NotFound();
            }

            var municipalidad = await _context.Municipalidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (municipalidad == null)
            {
                return NotFound();
            }

            return View(municipalidad);
        }

        // GET: Municipalidad/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Municipalidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreMunicipalidad,Departamento,Distrito,Direccion,Referencia,Aceptacion")] Municipalidad municipalidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(municipalidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(municipalidad);
        }

        // GET: Municipalidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Municipalidad == null)
            {
                return NotFound();
            }

            var municipalidad = await _context.Municipalidad.FindAsync(id);
            if (municipalidad == null)
            {
                return NotFound();
            }
            return View(municipalidad);
        }

        // POST: Municipalidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreMunicipalidad,Departamento,Distrito,Direccion,Referencia,Aceptacion")] Municipalidad municipalidad)
        {
            if (id != municipalidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(municipalidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MunicipalidadExists(municipalidad.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(municipalidad);
        }

        // GET: Municipalidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Municipalidad == null)
            {
                return NotFound();
            }

            var municipalidad = await _context.Municipalidad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (municipalidad == null)
            {
                return NotFound();
            }

            return View(municipalidad);
        }

        // POST: Municipalidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Municipalidad == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Municipalidad'  is null.");
            }
            var municipalidad = await _context.Municipalidad.FindAsync(id);
            if (municipalidad != null)
            {
                _context.Municipalidad.Remove(municipalidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MunicipalidadExists(int id)
        {
          return (_context.Municipalidad?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
