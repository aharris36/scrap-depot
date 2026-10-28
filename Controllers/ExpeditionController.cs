using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using scrap_depot.Data;
using scrap_depot.Models;
using scrap_depot.ViewModels;

namespace scrap_depot.Controllers;

public class ExpeditionController : Controller
{
    private readonly ScrapContext _context;
    public ExpeditionController(ScrapContext context)
    {
        _context = context;
    }

    // GET /Specials/Create?truckId=3 — the link from a truck's page passes the id,
    // so the dropdown can come up already on the right truck.
    public IActionResult Create()
    {
        var form = new ExpeditionFormViewModel
        {
            ScrapChoices = ScrapChoices()
        };

        return View(form);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ExpeditionFormViewModel form)
    {
        if (!ModelState.IsValid)
        {
            form.ScrapChoices = ScrapChoices(form.Expedition.ScrapIds);   // rebuild it
            return View(form);
        }

        _context.Expeditions.Add(form.Expedition);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Scrap");
    }

    // One place that knows how to build the list, because two actions need it.

    /**
    private SelectList ScrapChoices(int? selected) =>
        new SelectList(_context.Scrap.OrderBy(t => t.Name).ToList(), "Id", "Name", selected);
        */

    //ai fix
    private SelectList ScrapChoices(IEnumerable<int>? selectedIds = null)
        {
            return new SelectList(
                _context.Scrap.OrderBy(s => s.Id).ToList(),
                "Id",
                "Name",
                selectedIds);
        }
}
