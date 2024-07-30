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
    public class Pratik_BilgilerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Pratik_BilgilerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pratik_Bilgiler
        public async Task<IActionResult> Index()
        {
              return _context.pratik_bilgiler != null ? 
                          View(await _context.pratik_bilgiler.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.pratik_bilgiler'  is null.");
        }

        // GET: Pratik_Bilgiler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.pratik_bilgiler == null)
            {
                return NotFound();
            }

            var pratik_Bilgiler = await _context.pratik_bilgiler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pratik_Bilgiler == null)
            {
                return NotFound();
            }

            return View(pratik_Bilgiler);
        }

        // GET: Pratik_Bilgiler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pratik_Bilgiler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Icerik")] Pratik_Bilgiler pratik_Bilgiler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pratik_Bilgiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pratik_Bilgiler);
        }

        // GET: Pratik_Bilgiler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.pratik_bilgiler == null)
            {
                return NotFound();
            }

            var pratik_Bilgiler = await _context.pratik_bilgiler.FindAsync(id);
            if (pratik_Bilgiler == null)
            {
                return NotFound();
            }
            return View(pratik_Bilgiler);
        }

        // POST: Pratik_Bilgiler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Icerik")] Pratik_Bilgiler pratik_Bilgiler)
        {
            if (id != pratik_Bilgiler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pratik_Bilgiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Pratik_BilgilerExists(pratik_Bilgiler.Id))
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
            return View(pratik_Bilgiler);
        }

        // GET: Pratik_Bilgiler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.pratik_bilgiler == null)
            {
                return NotFound();
            }

            var pratik_Bilgiler = await _context.pratik_bilgiler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pratik_Bilgiler == null)
            {
                return NotFound();
            }

            return View(pratik_Bilgiler);
        }

        // POST: Pratik_Bilgiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.pratik_bilgiler == null)
            {
                return Problem("Entity set 'ApplicationDbContext.pratik_bilgiler'  is null.");
            }
            var pratik_Bilgiler = await _context.pratik_bilgiler.FindAsync(id);
            if (pratik_Bilgiler != null)
            {
                _context.pratik_bilgiler.Remove(pratik_Bilgiler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Pratik_BilgilerExists(int id)
        {
          return (_context.pratik_bilgiler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
