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
    public class Deyim_hikayeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Deyim_hikayeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Deyim_hikaye
        public async Task<IActionResult> Index()
        {
              return _context.deyim_hikaye != null ? 
                          View(await _context.deyim_hikaye.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.deyim_hikaye'  is null.");
        }

        // GET: Deyim_hikaye/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.deyim_hikaye == null)
            {
                return NotFound();
            }

            var deyim_hikaye = await _context.deyim_hikaye
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deyim_hikaye == null)
            {
                return NotFound();
            }

            return View(deyim_hikaye);
        }

        // GET: Deyim_hikaye/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deyim_hikaye/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Deyim,Anlam,Ornek")] Deyim_hikaye deyim_hikaye)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deyim_hikaye);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deyim_hikaye);
        }

        // GET: Deyim_hikaye/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.deyim_hikaye == null)
            {
                return NotFound();
            }

            var deyim_hikaye = await _context.deyim_hikaye.FindAsync(id);
            if (deyim_hikaye == null)
            {
                return NotFound();
            }
            return View(deyim_hikaye);
        }

        // POST: Deyim_hikaye/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Deyim,Anlam,Ornek")] Deyim_hikaye deyim_hikaye)
        {
            if (id != deyim_hikaye.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deyim_hikaye);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Deyim_hikayeExists(deyim_hikaye.Id))
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
            return View(deyim_hikaye);
        }

        // GET: Deyim_hikaye/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.deyim_hikaye == null)
            {
                return NotFound();
            }

            var deyim_hikaye = await _context.deyim_hikaye
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deyim_hikaye == null)
            {
                return NotFound();
            }

            return View(deyim_hikaye);
        }

        // POST: Deyim_hikaye/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.deyim_hikaye == null)
            {
                return Problem("Entity set 'ApplicationDbContext.deyim_hikaye'  is null.");
            }
            var deyim_hikaye = await _context.deyim_hikaye.FindAsync(id);
            if (deyim_hikaye != null)
            {
                _context.deyim_hikaye.Remove(deyim_hikaye);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Deyim_hikayeExists(int id)
        {
          return (_context.deyim_hikaye?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
