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
    public class Ani_sohbetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Ani_sohbetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ani_sohbet
        public async Task<IActionResult> Index()
        {
              return _context.ani_sohbet != null ? 
                          View(await _context.ani_sohbet.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ani_sohbet'  is null.");
        }

        // GET: Ani_sohbet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ani_sohbet == null)
            {
                return NotFound();
            }

            var ani_sohbet = await _context.ani_sohbet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ani_sohbet == null)
            {
                return NotFound();
            }

            return View(ani_sohbet);
        }

        // GET: Ani_sohbet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ani_sohbet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Baslik,Konu,Icerik,yayim_tarihi,Yazar")] Ani_sohbet ani_sohbet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ani_sohbet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ani_sohbet);
        }

        // GET: Ani_sohbet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ani_sohbet == null)
            {
                return NotFound();
            }

            var ani_sohbet = await _context.ani_sohbet.FindAsync(id);
            if (ani_sohbet == null)
            {
                return NotFound();
            }
            return View(ani_sohbet);
        }

        // POST: Ani_sohbet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Konu,Icerik,yayim_tarihi,Yazar")] Ani_sohbet ani_sohbet)
        {
            if (id != ani_sohbet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ani_sohbet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Ani_sohbetExists(ani_sohbet.Id))
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
            return View(ani_sohbet);
        }

        // GET: Ani_sohbet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ani_sohbet == null)
            {
                return NotFound();
            }

            var ani_sohbet = await _context.ani_sohbet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ani_sohbet == null)
            {
                return NotFound();
            }

            return View(ani_sohbet);
        }

        // POST: Ani_sohbet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ani_sohbet == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ani_sohbet'  is null.");
            }
            var ani_sohbet = await _context.ani_sohbet.FindAsync(id);
            if (ani_sohbet != null)
            {
                _context.ani_sohbet.Remove(ani_sohbet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Ani_sohbetExists(int id)
        {
          return (_context.ani_sohbet?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
