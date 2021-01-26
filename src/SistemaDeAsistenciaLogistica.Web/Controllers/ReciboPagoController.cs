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
    public class ReciboPagoController : Controller
    {
        private readonly SistemaDeAsistenciaLogisticaDbContext _context;

        public ReciboPagoController(SistemaDeAsistenciaLogisticaDbContext context)
        {
            _context = context;
        }

        // GET: ReciboPago
        public async Task<IActionResult> Index()
        {
            var sistemaDeAsistenciaLogisticaDbContext = _context.ReciboPago.Include(r => r.IdPedidoNavigation);
            return View(await sistemaDeAsistenciaLogisticaDbContext.ToListAsync());
        }

        // GET: ReciboPago/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reciboPago = await _context.ReciboPago
                .Include(r => r.IdPedidoNavigation)
                .FirstOrDefaultAsync(m => m.IdReciboPago == id);
            if (reciboPago == null)
            {
                return NotFound();
            }

            return View(reciboPago);
        }

        // GET: ReciboPago/Create
        public IActionResult Create()
        {
            ViewData["IdPedido"] = new SelectList(_context.Pedido, "IdPedido", "IdPedido");
            return View();
        }

        // POST: ReciboPago/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReciboPago,IdPedido")] ReciboPago reciboPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reciboPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPedido"] = new SelectList(_context.Pedido, "IdPedido", "IdPedido", reciboPago.IdPedido);
            return View(reciboPago);
        }

        // GET: ReciboPago/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reciboPago = await _context.ReciboPago.FindAsync(id);
            if (reciboPago == null)
            {
                return NotFound();
            }
            ViewData["IdPedido"] = new SelectList(_context.Pedido, "IdPedido", "IdPedido", reciboPago.IdPedido);
            return View(reciboPago);
        }

        // POST: ReciboPago/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReciboPago,IdPedido")] ReciboPago reciboPago)
        {
            if (id != reciboPago.IdReciboPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reciboPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReciboPagoExists(reciboPago.IdReciboPago))
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
            ViewData["IdPedido"] = new SelectList(_context.Pedido, "IdPedido", "IdPedido", reciboPago.IdPedido);
            return View(reciboPago);
        }

        // GET: ReciboPago/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reciboPago = await _context.ReciboPago
                .Include(r => r.IdPedidoNavigation)
                .FirstOrDefaultAsync(m => m.IdReciboPago == id);
            if (reciboPago == null)
            {
                return NotFound();
            }

            return View(reciboPago);
        }

        // POST: ReciboPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reciboPago = await _context.ReciboPago.FindAsync(id);
            _context.ReciboPago.Remove(reciboPago);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReciboPagoExists(int id)
        {
            return _context.ReciboPago.Any(e => e.IdReciboPago == id);
        }
    }
}

