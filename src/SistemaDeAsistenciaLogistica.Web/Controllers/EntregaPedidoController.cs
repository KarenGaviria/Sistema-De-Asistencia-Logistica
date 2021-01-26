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
    public class EntregaPedidoController : Controller
    {
        private readonly SistemaDeAsistenciaLogisticaDbContext _context;

        public EntregaPedidoController(SistemaDeAsistenciaLogisticaDbContext context)
        {
            _context = context;
        }

        // GET: EntregaPedido
        public async Task<IActionResult> Index()
        {
            var sistemaDeAsistenciaLogisticaDbContext = _context.EntregaPedido.Include(e => e.IdPedidoNavigation).Include(e => e.IdProduccionNavigation);
            return View(await sistemaDeAsistenciaLogisticaDbContext.ToListAsync());
        }

        // GET: EntregaPedido/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entregaPedido = await _context.EntregaPedido
                .Include(e => e.IdPedidoNavigation)
                .Include(e => e.IdProduccionNavigation)
                .FirstOrDefaultAsync(m => m.IdEntregaPedido == id);
            if (entregaPedido == null)
            {
                return NotFound();
            }

            return View(entregaPedido);
        }

        // GET: EntregaPedido/Create
        public IActionResult Create()
        {
            ViewData["IdPedido"] = new SelectList(_context.Pedido, "IdPedido", "IdPedido");
            ViewData["IdProduccion"] = new SelectList(_context.Produccion, "IdProduccion", "IdProduccion");
            return View();
        }

        // POST: EntregaPedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEntregaPedido,IdPedido,IdProduccion,FechaEntrega")] EntregaPedido entregaPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entregaPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPedido"] = new SelectList(_context.Pedido, "IdPedido", "IdPedido", entregaPedido.IdPedido);
            ViewData["IdProduccion"] = new SelectList(_context.Produccion, "IdProduccion", "IdProduccion", entregaPedido.IdProduccion);
            return View(entregaPedido);
        }

        // GET: EntregaPedido/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entregaPedido = await _context.EntregaPedido.FindAsync(id);
            if (entregaPedido == null)
            {
                return NotFound();
            }
            ViewData["IdPedido"] = new SelectList(_context.Pedido, "IdPedido", "IdPedido", entregaPedido.IdPedido);
            ViewData["IdProduccion"] = new SelectList(_context.Produccion, "IdProduccion", "IdProduccion", entregaPedido.IdProduccion);
            return View(entregaPedido);
        }

        // POST: EntregaPedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEntregaPedido,IdPedido,IdProduccion,FechaEntrega")] EntregaPedido entregaPedido)
        {
            if (id != entregaPedido.IdEntregaPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entregaPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntregaPedidoExists(entregaPedido.IdEntregaPedido))
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
            ViewData["IdPedido"] = new SelectList(_context.Pedido, "IdPedido", "IdPedido", entregaPedido.IdPedido);
            ViewData["IdProduccion"] = new SelectList(_context.Produccion, "IdProduccion", "IdProduccion", entregaPedido.IdProduccion);
            return View(entregaPedido);
        }

        // GET: EntregaPedido/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entregaPedido = await _context.EntregaPedido
                .Include(e => e.IdPedidoNavigation)
                .Include(e => e.IdProduccionNavigation)
                .FirstOrDefaultAsync(m => m.IdEntregaPedido == id);
            if (entregaPedido == null)
            {
                return NotFound();
            }

            return View(entregaPedido);
        }

        // POST: EntregaPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entregaPedido = await _context.EntregaPedido.FindAsync(id);
            _context.EntregaPedido.Remove(entregaPedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntregaPedidoExists(int id)
        {
            return _context.EntregaPedido.Any(e => e.IdEntregaPedido == id);
        }
    }
}
