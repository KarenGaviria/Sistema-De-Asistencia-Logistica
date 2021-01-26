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
    public class InsumoController : Controller
    {
        private readonly SistemaDeAsistenciaLogisticaDbContext _context;

        public InsumoController(SistemaDeAsistenciaLogisticaDbContext context)
        {
            _context = context;
        }

        // GET: Insumo
        public async Task<IActionResult> Index()
        {
            var sistemaDeAsistenciaLogisticaDbContext = _context.Insumos.Include(i => i.IdColorNavigation).Include(i => i.IdProveedorNavigation);
            return View(await sistemaDeAsistenciaLogisticaDbContext.ToListAsync());
        }

        // GET: Insumo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumos = await _context.Insumos
                .Include(i => i.IdColorNavigation)
                .Include(i => i.IdProveedorNavigation)
                .FirstOrDefaultAsync(m => m.IdInsumo == id);
            if (insumos == null)
            {
                return NotFound();
            }

            return View(insumos);
        }

        // GET: Insumo/Create
        public IActionResult Create()
        {
            ViewData["IdColor"] = new SelectList(_context.Colores, "IdColor", "Color");
            ViewData["IdProveedor"] = new SelectList(_context.Proveedor, "IdProveedor", "Distribuidora");
            return View();
        }

        // POST: Insumo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInsumo,NombreInsumo,IdColor,IdProveedor")] Insumos insumos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insumos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdColor"] = new SelectList(_context.Colores, "IdColor", "Color", insumos.IdColor);
            ViewData["IdProveedor"] = new SelectList(_context.Proveedor, "IdProveedor", "Distribuidora", insumos.IdProveedor);
            return View(insumos);
        }

        // GET: Insumo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumos = await _context.Insumos.FindAsync(id);
            if (insumos == null)
            {
                return NotFound();
            }
            ViewData["IdColor"] = new SelectList(_context.Colores, "IdColor", "Color", insumos.IdColor);
            ViewData["IdProveedor"] = new SelectList(_context.Proveedor, "IdProveedor", "Distribuidora", insumos.IdProveedor);
            return View(insumos);
        }

        // POST: Insumo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInsumo,NombreInsumo,IdColor,IdProveedor")] Insumos insumos)
        {
            if (id != insumos.IdInsumo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insumos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsumosExists(insumos.IdInsumo))
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
            ViewData["IdColor"] = new SelectList(_context.Colores, "IdColor", "Color", insumos.IdColor);
            ViewData["IdProveedor"] = new SelectList(_context.Proveedor, "IdProveedor", "Distribuidora", insumos.IdProveedor);
            return View(insumos);
        }

        // GET: Insumo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumos = await _context.Insumos
                .Include(i => i.IdColorNavigation)
                .Include(i => i.IdProveedorNavigation)
                .FirstOrDefaultAsync(m => m.IdInsumo == id);
            if (insumos == null)
            {
                return NotFound();
            }

            return View(insumos);
        }

        // POST: Insumo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insumos = await _context.Insumos.FindAsync(id);
            _context.Insumos.Remove(insumos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsumosExists(int id)
        {
            return _context.Insumos.Any(e => e.IdInsumo == id);
        }
    }
}
