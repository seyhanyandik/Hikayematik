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
    public class Tarihi_YerlerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Tarihi_YerlerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tarihi_Yerler
        public async Task<IActionResult> Index()
        {
              return _context.tarihi_yerler != null ? 
                          View(await _context.tarihi_yerler.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.tarihi_yerler'  is null.");
        }

        // GET: Tarihi_Yerler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tarihi_yerler == null)
            {
                return NotFound();
            }

            var tarihi_Yerler = await _context.tarihi_yerler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarihi_Yerler == null)
            {
                return NotFound();
            }

            return View(tarihi_Yerler);
        }

        // GET: Tarihi_Yerler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tarihi_Yerler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Lokasyon,Tarihce")] Tarihi_Yerler tarihi_Yerler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarihi_Yerler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarihi_Yerler);
        }

        // GET: Tarihi_Yerler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tarihi_yerler == null)
            {
                return NotFound();
            }

            var tarihi_Yerler = await _context.tarihi_yerler.FindAsync(id);
            if (tarihi_Yerler == null)
            {
                return NotFound();
            }
            return View(tarihi_Yerler);
        }

        // POST: Tarihi_Yerler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Lokasyon,Tarihce")] Tarihi_Yerler tarihi_Yerler)
        {
            if (id != tarihi_Yerler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarihi_Yerler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tarihi_YerlerExists(tarihi_Yerler.Id))
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
            return View(tarihi_Yerler);
        }

        // GET: Tarihi_Yerler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tarihi_yerler == null)
            {
                return NotFound();
            }

            var tarihi_Yerler = await _context.tarihi_yerler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tarihi_Yerler == null)
            {
                return NotFound();
            }

            return View(tarihi_Yerler);
        }

        // POST: Tarihi_Yerler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tarihi_yerler == null)
            {
                return Problem("Entity set 'ApplicationDbContext.tarihi_yerler'  is null.");
            }
            var tarihi_Yerler = await _context.tarihi_yerler.FindAsync(id);
            if (tarihi_Yerler != null)
            {
                _context.tarihi_yerler.Remove(tarihi_Yerler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tarihi_YerlerExists(int id)
        {
          return (_context.tarihi_yerler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
