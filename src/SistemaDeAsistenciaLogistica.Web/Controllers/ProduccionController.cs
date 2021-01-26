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
    public class ProduccionController : Controller
    {
        private readonly SistemaDeAsistenciaLogisticaDbContext _context;

        public ProduccionController(SistemaDeAsistenciaLogisticaDbContext context)
        {
            _context = context;
        }

        // GET: Produccion
        public async Task<IActionResult> Index()
        {
            var sistemaDeAsistenciaLogisticaDbContext = _context.Produccion.Include(p => p.IdEstadoNavigation).Include(p => p.IdPerfilNavigation).Include(p => p.IdProductoNavigation);
            return View(await sistemaDeAsistenciaLogisticaDbContext.ToListAsync());
        }

        // GET: Produccion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produccion = await _context.Produccion
                .Include(p => p.IdEstadoNavigation)
                .Include(p => p.IdPerfilNavigation)
                .Include(p => p.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdProduccion == id);
            if (produccion == null)
            {
                return NotFound();
            }

            return View(produccion);
        }

        // GET: Produccion/Create
        public IActionResult Create()
        {
            ViewData["IdEstado"] = new SelectList(_context.EstadoProduccion, "IdEstado", "EstadoProduccion1");
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdUsuarios", "PrimerApellido");
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre");
            return View();
        }

        // POST: Produccion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduccion,IdProducto,FechaProduccion,DetalleProducto,IdEstado,Cantidad,IdPerfil")] Produccion produccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstado"] = new SelectList(_context.EstadoProduccion, "IdEstado", "EstadoProduccion1", produccion.IdEstado);
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdUsuarios", "PrimerApellido", produccion.IdPerfil);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", produccion.IdProducto);
            return View(produccion);
        }

        // GET: Produccion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produccion = await _context.Produccion.FindAsync(id);
            if (produccion == null)
            {
                return NotFound();
            }
            ViewData["IdEstado"] = new SelectList(_context.EstadoProduccion, "IdEstado", "EstadoProduccion1", produccion.IdEstado);
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdUsuarios", "PrimerApellido", produccion.IdPerfil);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", produccion.IdProducto);
            return View(produccion);
        }

        // POST: Produccion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduccion,IdProducto,FechaProduccion,DetalleProducto,IdEstado,Cantidad,IdPerfil")] Produccion produccion)
        {
            if (id != produccion.IdProduccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduccionExists(produccion.IdProduccion))
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
            ViewData["IdEstado"] = new SelectList(_context.EstadoProduccion, "IdEstado", "EstadoProduccion1", produccion.IdEstado);
            ViewData["IdPerfil"] = new SelectList(_context.Perfil, "IdUsuarios", "PrimerApellido", produccion.IdPerfil);
            ViewData["IdProducto"] = new SelectList(_context.Producto, "IdProducto", "Nombre", produccion.IdProducto);
            return View(produccion);
        }

        // GET: Produccion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produccion = await _context.Produccion
                .Include(p => p.IdEstadoNavigation)
                .Include(p => p.IdPerfilNavigation)
                .Include(p => p.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdProduccion == id);
            if (produccion == null)
            {
                return NotFound();
            }

            return View(produccion);
        }

        // POST: Produccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produccion = await _context.Produccion.FindAsync(id);
            _context.Produccion.Remove(produccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduccionExists(int id)
        {
            return _context.Produccion.Any(e => e.IdProduccion == id);
        }
    }
}