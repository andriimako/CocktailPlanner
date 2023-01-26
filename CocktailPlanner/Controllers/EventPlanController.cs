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
    public class EventPlanController : Controller
    {
        private readonly CocktailPDbContext _context;

        public EventPlanController(CocktailPDbContext context)
        {
            _context = context;
        }

        // GET: EventPlan
        public async Task<IActionResult> Index()
        {
              return _context.EventPlans != null ? 
                          View(await _context.EventPlans.ToListAsync()) :
                          Problem("Entity set 'CocktailPDbContext.EventPlans'  is null.");
        }

        // GET: EventPlan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EventPlans == null)
            {
                return NotFound();
            }

            var eventPlan = await _context.EventPlans
                .FirstOrDefaultAsync(m => m.IdEvent == id);
            if (eventPlan == null)
            {
                return NotFound();
            }

            return View(eventPlan);
        }

        // GET: EventPlan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventPlan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEvent,Title,Description,Date")] EventPlan eventPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventPlan);
        }

        // GET: EventPlan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EventPlans == null)
            {
                return NotFound();
            }

            var eventPlan = await _context.EventPlans.FindAsync(id);
            if (eventPlan == null)
            {
                return NotFound();
            }
            return View(eventPlan);
        }

        // POST: EventPlan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEvent,Title,Description,Date")] EventPlan eventPlan)
        {
            if (id != eventPlan.IdEvent)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventPlanExists(eventPlan.IdEvent))
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
            return View(eventPlan);
        }

        // GET: EventPlan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EventPlans == null)
            {
                return NotFound();
            }

            var eventPlan = await _context.EventPlans
                .FirstOrDefaultAsync(m => m.IdEvent == id);
            if (eventPlan == null)
            {
                return NotFound();
            }

            return View(eventPlan);
        }

        // POST: EventPlan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EventPlans == null)
            {
                return Problem("Entity set 'CocktailPDbContext.EventPlans'  is null.");
            }
            var eventPlan = await _context.EventPlans.FindAsync(id);
            if (eventPlan != null)
            {
                _context.EventPlans.Remove(eventPlan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventPlanExists(int id)
        {
          return (_context.EventPlans?.Any(e => e.IdEvent == id)).GetValueOrDefault();
        }
    }
}
