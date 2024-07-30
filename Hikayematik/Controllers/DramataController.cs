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
    public class DramataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DramataController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Dramata
        public async Task<IActionResult> Index()
        {
              return _context.drama != null ? 
                          View(await _context.drama.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.drama'  is null.");
        }

        // GET: Dramata/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.drama == null)
            {
                return NotFound();
            }

            var drama = await _context.drama
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drama == null)
            {
                return NotFound();
            }

            return View(drama);
        }

        // GET: Dramata/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dramata/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Konu,Icerik,yayim_tarihi,Yazar")] Drama drama)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drama);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drama);
        }

        // GET: Dramata/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.drama == null)
            {
                return NotFound();
            }

            var drama = await _context.drama.FindAsync(id);
            if (drama == null)
            {
                return NotFound();
            }
            return View(drama);
        }

        // POST: Dramata/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Konu,Icerik,yayim_tarihi,Yazar")] Drama drama)
        {
            if (id != drama.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drama);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DramaExists(drama.Id))
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
            return View(drama);
        }

        // GET: Dramata/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.drama == null)
            {
                return NotFound();
            }

            var drama = await _context.drama
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drama == null)
            {
                return NotFound();
            }

            return View(drama);
        }

        // POST: Dramata/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.drama == null)
            {
                return Problem("Entity set 'ApplicationDbContext.drama'  is null.");
            }
            var drama = await _context.drama.FindAsync(id);
            if (drama != null)
            {
                _context.drama.Remove(drama);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DramaExists(int id)
        {
          return (_context.drama?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
