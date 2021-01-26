using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDeAsistenciaLogistica.Core.Domain;
using SistemaDeAsistenciaLogistica.Infrastructure.Data;

namespace SistemaDeAsistenciaLogistica.Web.Controllers
{
    public class BarrioController : Controller
    {
        private readonly SistemaDeAsistenciaLogisticaDbContext _context;

        public BarrioController(SistemaDeAsistenciaLogisticaDbContext context)
        {
            _context = context;
        }

        // GET: Barrio
        public async Task<IActionResult> Index()
        {
            return View(await _context.Barrios.ToListAsync());
        }

        // GET: Barrio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barrios = await _context.Barrios
                .FirstOrDefaultAsync(m => m.IdBarrio == id);
            if (barrios == null)
            {
                return NotFound();
            }

            return View(barrios);
        }

        // GET: Barrio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Barrio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBarrio,NombreBarrio")] Barrios barrios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barrios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(barrios);
        }

        // GET: Barrio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barrios = await _context.Barrios.FindAsync(id);
            if (barrios == null)
            {
                return NotFound();
            }
            return View(barrios);
        }

        // POST: Barrio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBarrio,NombreBarrio")] Barrios barrios)
        {
            if (id != barrios.IdBarrio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barrios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarriosExists(barrios.IdBarrio))
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
            return View(barrios);
        }

        // GET: Barrio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barrios = await _context.Barrios
                .FirstOrDefaultAsync(m => m.IdBarrio == id);
            if (barrios == null)
            {
                return NotFound();
            }

            return View(barrios);
        }

        // POST: Barrio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barrios = await _context.Barrios.FindAsync(id);
            _context.Barrios.Remove(barrios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarriosExists(int id)
        {
            return _context.Barrios.Any(e => e.IdBarrio == id);
        }
    }
}
