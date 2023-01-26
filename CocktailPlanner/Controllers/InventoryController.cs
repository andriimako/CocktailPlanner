using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CocktailPlanner.DataLink;
using CocktailPlanner.Models;

namespace CocktailPlanner.Controllers
{
    public class InventoryController : Controller
    {
        private readonly CocktailPDbContext _context;

        public InventoryController(CocktailPDbContext context)
        {
            _context = context;
        }

        // GET: Inventory
        public async Task<IActionResult> Index()
        {
              return _context.Cocktails != null ? 
                          View(await _context.Cocktails.ToListAsync()) :
                          Problem("Entity set 'CocktailPDbContext.Cocktails'  is null.");
        }

        // GET: Inventory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cocktails == null)
            {
                return NotFound();
            }

            var cocktail = await _context.Cocktails
                .FirstOrDefaultAsync(m => m.IdCocktail == id);
            if (cocktail == null)
            {
                return NotFound();
            }

            return View(cocktail);
        }

        // GET: Inventory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCocktail,Name,Description,Image")] Cocktail cocktail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cocktail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cocktail);
        }

        // GET: Inventory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cocktails == null)
            {
                return NotFound();
            }

            var cocktail = await _context.Cocktails.FindAsync(id);
            if (cocktail == null)
            {
                return NotFound();
            }
            return View(cocktail);
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCocktail,Name,Description,Image")] Cocktail cocktail)
        {
            if (id != cocktail.IdCocktail)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cocktail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CocktailExists(cocktail.IdCocktail))
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
            return View(cocktail);
        }

        // GET: Inventory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cocktails == null)
            {
                return NotFound();
            }

            var cocktail = await _context.Cocktails
                .FirstOrDefaultAsync(m => m.IdCocktail == id);
            if (cocktail == null)
            {
                return NotFound();
            }

            return View(cocktail);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cocktails == null)
            {
                return Problem("Entity set 'CocktailPDbContext.Cocktails'  is null.");
            }
            var cocktail = await _context.Cocktails.FindAsync(id);
            if (cocktail != null)
            {
                _context.Cocktails.Remove(cocktail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CocktailExists(int id)
        {
          return (_context.Cocktails?.Any(e => e.IdCocktail == id)).GetValueOrDefault();
        }
    }
}
