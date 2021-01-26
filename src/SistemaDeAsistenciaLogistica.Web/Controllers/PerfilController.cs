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
    public class PerfilController : Controller
    {
        private readonly SistemaDeAsistenciaLogisticaDbContext _context;

        public PerfilController(SistemaDeAsistenciaLogisticaDbContext context)
        {
            _context = context;
        }

        // GET: Perfil
        public async Task<IActionResult> Index()
        {
            var sistemaDeAsistenciaLogisticaDbContext = _context.Perfil.Include(p => p.Aspnetusers);
            return View(await sistemaDeAsistenciaLogisticaDbContext.ToListAsync());
        }

        // GET: Perfil/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfil
                .Include(p => p.Aspnetusers)
                .FirstOrDefaultAsync(m => m.IdUsuarios == id);
            if (perfil == null)
            {
                return NotFound();
            }

            return View(perfil);
        }

        // GET: Perfil/Create
        public IActionResult Create()
        {
            ViewData["AspnetusersId"] = new SelectList(_context.Aspnetusers, "Id", "Email");
            return View();
        }

        // POST: Perfil/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuarios,PrimerNombre,PrimerApellido,Direccion,AspnetusersId")] Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perfil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AspnetusersId"] = new SelectList(_context.Aspnetusers, "Id", "Email", perfil.AspnetusersId);
            return View(perfil);
        }

        // GET: Perfil/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfil.FindAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }
            ViewData["AspnetusersId"] = new SelectList(_context.Aspnetusers, "Id", "Email", perfil.AspnetusersId);
            return View(perfil);
        }

        // POST: Perfil/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuarios,PrimerNombre,PrimerApellido,Direccion,AspnetusersId")] Perfil perfil)
        {
            if (id != perfil.IdUsuarios)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perfil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfilExists(perfil.IdUsuarios))
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
            ViewData["AspnetusersId"] = new SelectList(_context.Aspnetusers, "Id", "Email", perfil.AspnetusersId);
            return View(perfil);
        }

        // GET: Perfil/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfil = await _context.Perfil
                .Include(p => p.Aspnetusers)
                .FirstOrDefaultAsync(m => m.IdUsuarios == id);
            if (perfil == null)
            {
                return NotFound();
            }

            return View(perfil);
        }

        // POST: Perfil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perfil = await _context.Perfil.FindAsync(id);
            _context.Perfil.Remove(perfil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerfilExists(int id)
        {
            return _context.Perfil.Any(e => e.IdUsuarios == id);
        }
    }
}