using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hikayematik.Data;
using Hikayematik.Models;

namespace Hikayematik.Controllers
{
    public class MasalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MasalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Masals
        public async Task<IActionResult> Index()
        {
              return _context.masal != null ? 
                          View(await _context.masal.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.masal'  is null.");
        }

        // GET: Masals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.masal == null)
            {
                return NotFound();
            }

            var masal = await _context.masal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (masal == null)
            {
                return NotFound();
            }

            return View(masal);
        }

        // GET: Masals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Masals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Konu,Icerik,Yazar,Ders")] Masal masal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(masal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(masal);
        }

        // GET: Masals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.masal == null)
            {
                return NotFound();
            }

            var masal = await _context.masal.FindAsync(id);
            if (masal == null)
            {
                return NotFound();
            }
            return View(masal);
        }

        // POST: Masals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Konu,Icerik,Yazar,Ders")] Masal masal)
        {
            if (id != masal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(masal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MasalExists(masal.Id))
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
            return View(masal);
        }

        // GET: Masals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.masal == null)
            {
                return NotFound();
            }

            var masal = await _context.masal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (masal == null)
            {
                return NotFound();
            }

            return View(masal);
        }

        // POST: Masals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.masal == null)
            {
                return Problem("Entity set 'ApplicationDbContext.masal'  is null.");
            }
            var masal = await _context.masal.FindAsync(id);
            if (masal != null)
            {
                _context.masal.Remove(masal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MasalExists(int id)
        {
          return (_context.masal?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
