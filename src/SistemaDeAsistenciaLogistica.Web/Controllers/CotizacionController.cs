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
    public class CotizacionController : Controller
    {
        private readonly SistemaDeAsistenciaLogisticaDbContext _context;

        public CotizacionController(SistemaDeAsistenciaLogisticaDbContext context)
        {
            _context = context;
        }

        // GET: Cotizacion
        public async Task<IActionResult> Index()
        {
            var sistemaDeAsistenciaLogisticaDbContext = _context.Cotizacion.Include(c => c.IdPerfilNavigation).Include(c => c.IdProductoNavigation);
            return View(await sistemaDeAsistenciaLogisticaDbContext.ToListAsync());
        }

        // GET: Cotizacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizacion
                .Include(c => c.IdPerfilNavigation)
                .Include(c => c.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdCotizacion == id);
            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }

        // GET: Cotizacion/Create
        public IActionResult Create()
        {
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdUsuarios", "PrimerApellido");
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre");
            return View();
        }

        // POST: Cotizacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCotizacion,IdPerfil,IdProducto,Cantidad,ValorTotal")] Cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cotizacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdUsuarios", "PrimerApellido", cotizacion.IdPerfil);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", cotizacion.IdProducto);
            return View(cotizacion);
        }

        // GET: Cotizacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizacion.FindAsync(id);
            if (cotizacion == null)
            {
                return NotFound();
            }
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdUsuarios", "PrimerApellido", cotizacion.IdPerfil);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", cotizacion.IdProducto);
            return View(cotizacion);
        }

        // POST: Cotizacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCotizacion,IdPerfil,IdProducto,Cantidad,ValorTotal")] Cotizacion cotizacion)
        {
            if (id != cotizacion.IdCotizacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cotizacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CotizacionExists(cotizacion.IdCotizacion))
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
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdUsuarios", "PrimerApellido", cotizacion.IdPerfil);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", cotizacion.IdProducto);
            return View(cotizacion);
        }

        // GET: Cotizacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizacion
                .Include(c => c.IdPerfilNavigation)
                .Include(c => c.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdCotizacion == id);
            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }

        // POST: Cotizacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cotizacion = await _context.Cotizacion.FindAsync(id);
            _context.Cotizacion.Remove(cotizacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CotizacionExists(int id)
        {
            return _context.Cotizacion.Any(e => e.IdCotizacion == id);
        }
    }
}
