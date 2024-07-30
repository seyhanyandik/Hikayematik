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
    public class HikayesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HikayesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hikayes
        public async Task<IActionResult> Index()
        {
              return _context.hikaye != null ? 
                          View(await _context.hikaye.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.hikaye'  is null.");
        }

        // GET: Hikayes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.hikaye == null)
            {
                return NotFound();
            }

            var hikaye = await _context.hikaye
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hikaye == null)
            {
                return NotFound();
            }

            return View(hikaye);
        }

        // GET: Hikayes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hikayes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Konu,Icerik,yayim_tarihi,Yazar")] Hikaye hikaye)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hikaye);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hikaye);
        }

        // GET: Hikayes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.hikaye == null)
            {
                return NotFound();
            }

            var hikaye = await _context.hikaye.FindAsync(id);
            if (hikaye == null)
            {
                return NotFound();
            }
            return View(hikaye);
        }

        // POST: Hikayes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Konu,Icerik,yayim_tarihi,Yazar")] Hikaye hikaye)
        {
            if (id != hikaye.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hikaye);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HikayeExists(hikaye.Id))
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
            return View(hikaye);
        }

        // GET: Hikayes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.hikaye == null)
            {
                return NotFound();
            }

            var hikaye = await _context.hikaye
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hikaye == null)
            {
                return NotFound();
            }

            return View(hikaye);
        }

        // POST: Hikayes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.hikaye == null)
            {
                return Problem("Entity set 'ApplicationDbContext.hikaye'  is null.");
            }
            var hikaye = await _context.hikaye.FindAsync(id);
            if (hikaye != null)
            {
                _context.hikaye.Remove(hikaye);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HikayeExists(int id)
        {
          return (_context.hikaye?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
