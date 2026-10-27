using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scrap_depot.Data;
using scrap_depot.Models;

namespace scrap_depot.Controllers;

public class ScrapController : Controller
{

    private readonly ScrapContext _context;

    public ScrapController(ScrapContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View(_context.Scrap.ToList());
    }
    public IActionResult Details(int id)
    {
        var scrapItem = _context.Scrap
            .Include(c => c.Expeditions)
            .FirstOrDefault(c => c.Id == id);
        if (scrapItem == null)
        {
            return NotFound();
        }
        return View(scrapItem);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Scrap scrapItem)
    {
        if (!ModelState.IsValid)
        {
            return View(scrapItem);
        }

        _context.Scrap.Add(scrapItem);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scrap = await _context.Scrap.FindAsync(id);
            if (scrap == null)
            {
                return NotFound();
            }
            return View(scrap);
        }

        // POST: ScrapScaffold/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Credits,Weight,Deposited,TwoHanded")] Scrap scrap)
        {
            if (id != scrap.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scrap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScrapExists(scrap.Id))
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
            return View(scrap);
        }

        // GET: ScrapScaffold/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scrap = await _context.Scrap
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scrap == null)
            {
                return NotFound();
            }

            return View(scrap);
        }

        // POST: ScrapScaffold/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scrap = await _context.Scrap.FindAsync(id);
            if (scrap != null)
            {
                _context.Scrap.Remove(scrap);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ScrapExists(int id)
        {
            return _context.Scrap.Any(e => e.Id == id);
        }
    
}
