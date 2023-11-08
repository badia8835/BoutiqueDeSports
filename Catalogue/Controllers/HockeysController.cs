using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Catalogue.DataBase;
using Catalogue.Models;

namespace Catalogue.Controllers
{
    public class HockeysController : Controller
    {
        private readonly CatalogueContext _context;

        public HockeysController(CatalogueContext context)
        {
            _context = context;
        }

        // GET: Hockeys
        public async Task<IActionResult> Index()
        {
              return _context.Hockeys != null ? 
                          View(await _context.Hockeys.ToListAsync()) :
                          Problem("Entity set 'CatalogueContext.Hockeys'  is null.");
        }

        // GET: Hockeys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hockeys == null)
            {
                return NotFound();
            }

            var hockey = await _context.Hockeys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hockey == null)
            {
                return NotFound();
            }

            return View(hockey);
        }

        // GET: Hockeys/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hockeys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomProduit,Marque,Taille,QuantiteEnInventaire,Photo,Categorie,DescriptionDetaillee")] Hockey hockey)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hockey);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hockey);
        }

        // GET: Hockeys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hockeys == null)
            {
                return NotFound();
            }

            var hockey = await _context.Hockeys.FindAsync(id);
            if (hockey == null)
            {
                return NotFound();
            }
            return View(hockey);
        }

        // POST: Hockeys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomProduit,Marque,Taille,QuantiteEnInventaire,Photo,Categorie,DescriptionDetaillee")] Hockey hockey)
        {
            if (id != hockey.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hockey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HockeyExists(hockey.Id))
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
            return View(hockey);
        }

        // GET: Hockeys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hockeys == null)
            {
                return NotFound();
            }

            var hockey = await _context.Hockeys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hockey == null)
            {
                return NotFound();
            }

            return View(hockey);
        }

        // POST: Hockeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hockeys == null)
            {
                return Problem("Entity set 'CatalogueContext.Hockeys'  is null.");
            }
            var hockey = await _context.Hockeys.FindAsync(id);
            if (hockey != null)
            {
                _context.Hockeys.Remove(hockey);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HockeyExists(int id)
        {
          return (_context.Hockeys?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
