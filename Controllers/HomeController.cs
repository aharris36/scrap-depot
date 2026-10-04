using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using scrap_depot.Data;
using scrap_depot.Models;

namespace scrap_depot.Controllers;

public class HomeController : Controller
{
    private readonly ScrapContext _context;

    public HomeController(ScrapContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewData["Featured"] = _context.Scrap.FirstOrDefault();
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
