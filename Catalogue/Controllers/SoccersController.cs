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
    public class SoccersController : Controller
    {
        private readonly CatalogueContext _context;

        public SoccersController(CatalogueContext context)
        {
            _context = context;
        }

        // GET: Soccers
        public async Task<IActionResult> Index()
        {
              return _context.Soccers != null ? 
                          View(await _context.Soccers.ToListAsync()) :
                          Problem("Entity set 'CatalogueContext.Soccers'  is null.");
        }

        // GET: Soccers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Soccers == null)
            {
                return NotFound();
            }

            var soccer = await _context.Soccers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soccer == null)
            {
                return NotFound();
            }

            return View(soccer);
        }

        // GET: Soccers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Soccers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomProduit,Marque,Taille,QuantiteEnInventaire,Photo,Categorie,DescriptionDetaillee")] Soccer soccer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(soccer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(soccer);
        }

        // GET: Soccers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Soccers == null)
            {
                return NotFound();
            }

            var soccer = await _context.Soccers.FindAsync(id);
            if (soccer == null)
            {
                return NotFound();
            }
            return View(soccer);
        }

        // POST: Soccers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomProduit,Marque,Taille,QuantiteEnInventaire,Photo,Categorie,DescriptionDetaillee")] Soccer soccer)
        {
            if (id != soccer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soccer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoccerExists(soccer.Id))
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
            return View(soccer);
        }

        // GET: Soccers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Soccers == null)
            {
                return NotFound();
            }

            var soccer = await _context.Soccers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (soccer == null)
            {
                return NotFound();
            }

            return View(soccer);
        }

        // POST: Soccers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Soccers == null)
            {
                return Problem("Entity set 'CatalogueContext.Soccers'  is null.");
            }
            var soccer = await _context.Soccers.FindAsync(id);
            if (soccer != null)
            {
                _context.Soccers.Remove(soccer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoccerExists(int id)
        {
          return (_context.Soccers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
