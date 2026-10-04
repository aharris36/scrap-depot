using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
        var scrapItem = _context.Scrap.FirstOrDefault(c => c.Id == id);
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
    
}
