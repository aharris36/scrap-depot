using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scrap_depot.Data;
using scrap_depot.Models;

namespace scrap_depot.Controllers;

public class ExpeditionController : Controller
{
    private readonly ScrapContext _context;
    public ExpeditionController(ScrapContext context)
    {
        _context = context;
    }
    public IActionResult Create()
    {
        return View();
    }
    
}