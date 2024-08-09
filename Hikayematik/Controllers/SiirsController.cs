using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hikayematik.Data;
using Hikayematik.Models;
using Microsoft.AspNetCore.Authorization;

namespace Hikayematik.Controllers
{
    public class SiirsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SiirsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Siirs
        public async Task<IActionResult> Index()
        {
              return _context.siir != null ? 
                          View(await _context.siir.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.siir'  is null.");
        }

        // GET: Siirs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.siir == null)
            {
                return NotFound();
            }

            var siir = await _context.siir
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siir == null)
            {
                return NotFound();
            }

            return View(siir);
        }

        // GET: Siirs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Siirs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Sair,Icerik,yayim_tarihi")] Siir siir)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siir);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(siir);
        }

        // GET: Siirs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.siir == null)
            {
                return NotFound();
            }

            var siir = await _context.siir.FindAsync(id);
            if (siir == null)
            {
                return NotFound();
            }
            return View(siir);
        }

        // POST: Siirs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Sair,Icerik,yayim_tarihi")] Siir siir)
        {
            if (id != siir.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siir);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiirExists(siir.Id))
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
            return View(siir);
        }

        // GET: Siirs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.siir == null)
            {
                return NotFound();
            }

            var siir = await _context.siir
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siir == null)
            {
                return NotFound();
            }

            return View(siir);
        }

        // POST: Siirs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.siir == null)
            {
                return Problem("Entity set 'ApplicationDbContext.siir'  is null.");
            }
            var siir = await _context.siir.FindAsync(id);
            if (siir != null)
            {
                _context.siir.Remove(siir);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiirExists(int id)
        {
          return (_context.siir?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
