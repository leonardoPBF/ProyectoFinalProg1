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
    public class FormacionAcademicaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormacionAcademicaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FormacionAcademica
        public async Task<IActionResult> Index()
        {
              return _context.FormacionAcademica != null ? 
                          View(await _context.FormacionAcademica.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.FormacionAcademica'  is null.");
        }

        // GET: FormacionAcademica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FormacionAcademica == null)
            {
                return NotFound();
            }

            var formacionAcademica = await _context.FormacionAcademica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formacionAcademica == null)
            {
                return NotFound();
            }

            return View(formacionAcademica);
        }

        // GET: FormacionAcademica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormacionAcademica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Universidad,Carrera,AñoGraduacion,IdAlcalde")] FormacionAcademica formacionAcademica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formacionAcademica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formacionAcademica);
        }

        // GET: FormacionAcademica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FormacionAcademica == null)
            {
                return NotFound();
            }

            var formacionAcademica = await _context.FormacionAcademica.FindAsync(id);
            if (formacionAcademica == null)
            {
                return NotFound();
            }
            return View(formacionAcademica);
        }

        // POST: FormacionAcademica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Universidad,Carrera,AñoGraduacion,IdAlcalde")] FormacionAcademica formacionAcademica)
        {
            if (id != formacionAcademica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formacionAcademica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormacionAcademicaExists(formacionAcademica.Id))
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
            return View(formacionAcademica);
        }

        // GET: FormacionAcademica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FormacionAcademica == null)
            {
                return NotFound();
            }

            var formacionAcademica = await _context.FormacionAcademica
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formacionAcademica == null)
            {
                return NotFound();
            }

            return View(formacionAcademica);
        }

        // POST: FormacionAcademica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FormacionAcademica == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FormacionAcademica'  is null.");
            }
            var formacionAcademica = await _context.FormacionAcademica.FindAsync(id);
            if (formacionAcademica != null)
            {
                _context.FormacionAcademica.Remove(formacionAcademica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormacionAcademicaExists(int id)
        {
          return (_context.FormacionAcademica?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
