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
    public class BiyografisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BiyografisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Biyografis
        public async Task<IActionResult> Index()
        {
              return _context.biyografi != null ? 
                          View(await _context.biyografi.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.biyografi'  is null.");
        }

        // GET: Biyografis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.biyografi == null)
            {
                return NotFound();
            }

            var biyografi = await _context.biyografi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biyografi == null)
            {
                return NotFound();
            }

            return View(biyografi);
   
        }

        // GET: Biyografis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Biyografis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,dogum_tarihi,olum_tarihi,Meslek,biyografi")] Biyografi gelen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gelen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Biyografis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.biyografi == null)
            {
                return NotFound();
            }

            var biyografi = await _context.biyografi.FindAsync(id);
            if (biyografi == null)
            {
                return NotFound();
            }
            return View(biyografi);
        }

        // POST: Biyografis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,dogum_tarihi,olum_tarihi,Meslek,biyografi")] Biyografi biografi)
        {
            if (id != biografi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(biografi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiyografiExists(biografi.Id))
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
            return View(biografi);
        }

        // GET: Biyografis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.biyografi == null)
            {
                return NotFound();
            }

            var biyografi = await _context.biyografi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (biyografi == null)
            {
                return NotFound();
            }

            return View(biyografi);
        }

        // POST: Biyografis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.biyografi == null)
            {
                return Problem("Entity set 'ApplicationDbContext.biyografi'  is null.");
            }
            var biyografi = await _context.biyografi.FindAsync(id);
            if (biyografi != null)
            {
                _context.biyografi.Remove(biyografi);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiyografiExists(int id)
        {
          return (_context.biyografi?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
