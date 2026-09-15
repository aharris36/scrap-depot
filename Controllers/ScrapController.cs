using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using scrap_depot.Models;

namespace scrap_depot.Controllers;

public class ScrapController : Controller
{
    public IActionResult Index()
    {
        return View(ScrapData.All);
    }
}
