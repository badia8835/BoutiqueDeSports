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
    public class VelosController : Controller
    {
        private readonly CatalogueContext _context;

        public VelosController(CatalogueContext context)
        {
            _context = context;
        }

        // GET: Veloes
        public async Task<IActionResult> Index()
        {
              return _context.Velos != null ? 
                          View(await _context.Velos.ToListAsync()) :
                          Problem("Entity set 'CatalogueContext.Velos'  is null.");
        }

        // GET: Veloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Velos == null)
            {
                return NotFound();
            }

            var velo = await _context.Velos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (velo == null)
            {
                return NotFound();
            }

            return View(velo);
        }

        // GET: Veloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomProduit,Marque,Taille,QuantiteEnInventaire,Photo,Categorie,DescriptionDetaillee")] Velo velo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(velo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(velo);
        }

        // GET: Veloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Velos == null)
            {
                return NotFound();
            }

            var velo = await _context.Velos.FindAsync(id);
            if (velo == null)
            {
                return NotFound();
            }
            return View(velo);
        }

        // POST: Veloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomProduit,Marque,Taille,QuantiteEnInventaire,Photo,Categorie,DescriptionDetaillee")] Velo velo)
        {
            if (id != velo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(velo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeloExists(velo.Id))
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
            return View(velo);
        }

        // GET: Veloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Velos == null)
            {
                return NotFound();
            }

            var velo = await _context.Velos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (velo == null)
            {
                return NotFound();
            }

            return View(velo);
        }

        // POST: Veloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Velos == null)
            {
                return Problem("Entity set 'CatalogueContext.Velos'  is null.");
            }
            var velo = await _context.Velos.FindAsync(id);
            if (velo != null)
            {
                _context.Velos.Remove(velo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeloExists(int id)
        {
          return (_context.Velos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
