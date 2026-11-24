using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scrap_depot.Data;
using scrap_depot.Models;

namespace scrap_depot.Controllers;


[ApiController]
[Route("api/scrap")]
public class ScrapApiController : ControllerBase
{
    private readonly ScrapContext _context;

    public ScrapApiController(ScrapContext context)
    {
        _context = context;
    }

    // GET /api/trucks
    [HttpGet]
    public async Task<List<Scrap>> GetAll()
    {
        return await _context.Scrap.ToListAsync();
    }

    // GET /api/cryptids/1
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Scrap>> GetOne(int id)
    {
        //include expeditions didn't seem to work
        return await _context.Scrap.FirstAsync(c => c.Id == id);
    }
}