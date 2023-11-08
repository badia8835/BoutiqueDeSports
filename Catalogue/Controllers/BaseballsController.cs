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
    public class BaseballsController : Controller
    {
        private readonly CatalogueContext _context;

        public BaseballsController(CatalogueContext context)
        {
            _context = context;
        }

        // GET: Baseballs
        public async Task<IActionResult> Index()
        {
              return _context.Baseballs != null ? 
                          View(await _context.Baseballs.ToListAsync()) :
                          Problem("Entity set 'CatalogueContext.Baseballs'  is null.");
        }

        // GET: Baseballs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Baseballs == null)
            {
                return NotFound();
            }

            var baseball = await _context.Baseballs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseball == null)
            {
                return NotFound();
            }

            return View(baseball);
        }

        // GET: Baseballs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Baseballs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomProduit,Marque,Taille,QuantiteEnInventaire,Photo,Categorie,DescriptionDetaillee")] Baseball baseball)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseball);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baseball);
        }

        // GET: Baseballs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Baseballs == null)
            {
                return NotFound();
            }

            var baseball = await _context.Baseballs.FindAsync(id);
            if (baseball == null)
            {
                return NotFound();
            }
            return View(baseball);
        }

        // POST: Baseballs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomProduit,Marque,Taille,QuantiteEnInventaire,Photo,Categorie,DescriptionDetaillee")] Baseball baseball)
        {
            if (id != baseball.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseball);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseballExists(baseball.Id))
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
            return View(baseball);
        }

        // GET: Baseballs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Baseballs == null)
            {
                return NotFound();
            }

            var baseball = await _context.Baseballs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseball == null)
            {
                return NotFound();
            }

            return View(baseball);
        }

        // POST: Baseballs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Baseballs == null)
            {
                return Problem("Entity set 'CatalogueContext.Baseballs'  is null.");
            }
            var baseball = await _context.Baseballs.FindAsync(id);
            if (baseball != null)
            {
                _context.Baseballs.Remove(baseball);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseballExists(int id)
        {
          return (_context.Baseballs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
