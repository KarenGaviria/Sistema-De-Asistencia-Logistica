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
    public class PedidoController : Controller
    {
        private readonly SistemaDeAsistenciaLogisticaDbContext _context;

        public PedidoController(SistemaDeAsistenciaLogisticaDbContext context)
        {
            _context = context;
        }

        // GET: Pedido
        public async Task<IActionResult> Index()
        {
            var sistemaDeAsistenciaLogisticaDbContext = _context.Pedido.Include(p => p.IdBarrioNavigation).Include(p => p.IdCotizacionNavigation);
            return View(await sistemaDeAsistenciaLogisticaDbContext.ToListAsync());
        }

        // GET: Pedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.IdBarrioNavigation)
                .Include(p => p.IdCotizacionNavigation)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedido/Create
        public IActionResult Create()
        {
            ViewData["IdBarrio"] = new SelectList(_context.Barrios, "IdBarrio", "NombreBarrio");
            ViewData["IdCotizacion"] = new SelectList(_context.Cotizacion, "IdCotizacion", "IdCotizacion");
            return View();
        }

        // POST: Pedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPedido,IdCotizacion,FechaPedido,LugarEntrega,IdBarrio")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBarrio"] = new SelectList(_context.Barrios, "IdBarrio", "NombreBarrio", pedido.IdBarrio);
            ViewData["IdCotizacion"] = new SelectList(_context.Cotizacion, "IdCotizacion", "IdCotizacion", pedido.IdCotizacion);
            return View(pedido);
        }

        // GET: Pedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["IdBarrio"] = new SelectList(_context.Barrios, "IdBarrio", "NombreBarrio", pedido.IdBarrio);
            ViewData["IdCotizacion"] = new SelectList(_context.Cotizacion, "IdCotizacion", "IdCotizacion", pedido.IdCotizacion);
            return View(pedido);
        }

        // POST: Pedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedido,IdCotizacion,FechaPedido,LugarEntrega,IdBarrio")] Pedido pedido)
        {
            if (id != pedido.IdPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.IdPedido))
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
            ViewData["IdBarrio"] = new SelectList(_context.Barrios, "IdBarrio", "NombreBarrio", pedido.IdBarrio);
            ViewData["IdCotizacion"] = new SelectList(_context.Cotizacion, "IdCotizacion", "IdCotizacion", pedido.IdCotizacion);
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .Include(p => p.IdBarrioNavigation)
                .Include(p => p.IdCotizacionNavigation)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.IdPedido == id);
        }
    }
}
