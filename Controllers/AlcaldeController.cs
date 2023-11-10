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
    public class AlcaldeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlcaldeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alcalde
        public async Task<IActionResult> Index()
        {
              return _context.Alcalde != null ? 
                          View(await _context.Alcalde.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Alcalde'  is null.");
        }

        // GET: Alcalde/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alcalde == null)
            {
                return NotFound();
            }

            var alcalde = await _context.Alcalde
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alcalde == null)
            {
                return NotFound();
            }

            return View(alcalde);
        }

        // GET: Alcalde/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alcalde/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombres,Apellidos,InicioAlcaldia,Aceptacion,MunicipalidadId")] Alcalde alcalde)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alcalde);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alcalde);
        }

        // GET: Alcalde/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Alcalde == null)
            {
                return NotFound();
            }

            var alcalde = await _context.Alcalde.FindAsync(id);
            if (alcalde == null)
            {
                return NotFound();
            }
            return View(alcalde);
        }

        // POST: Alcalde/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombres,Apellidos,InicioAlcaldia,Aceptacion,MunicipalidadId")] Alcalde alcalde)
        {
            if (id != alcalde.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alcalde);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlcaldeExists(alcalde.Id))
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
            return View(alcalde);
        }

        // GET: Alcalde/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alcalde == null)
            {
                return NotFound();
            }

            var alcalde = await _context.Alcalde
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alcalde == null)
            {
                return NotFound();
            }

            return View(alcalde);
        }

        // POST: Alcalde/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alcalde == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Alcalde'  is null.");
            }
            var alcalde = await _context.Alcalde.FindAsync(id);
            if (alcalde != null)
            {
                _context.Alcalde.Remove(alcalde);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlcaldeExists(int id)
        {
          return (_context.Alcalde?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
