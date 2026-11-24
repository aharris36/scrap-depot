using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scrap_depot.Data;
using scrap_depot.Models;
using scrap_depot.DTO;

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
    public async Task<List<ScrapDTO>> GetAll()
    {
        var scrap = await _context.Scrap
            .Include(t => t.Expeditions)
            .ToListAsync();

        return scrap.Select(ToDto).ToList();
    }

    // GET /api/trucks/2
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ScrapDTO>> GetOne(int id)
    {
        var scrap = await _context.Scrap
            .Include(t => t.Expeditions)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (scrap == null)
        {
            return NotFound();
        }

        return ToDto(scrap);
    }

    // inside TrucksApiController, at the bottom
    private static ScrapDTO ToDto(Scrap scrap) => new ScrapDTO
    {
        Id = scrap.Id,
        Name = scrap.Name,
        Description = scrap.Description,
        Credits = scrap.Credits,
        Weight = scrap.Weight,
        Deposited = scrap.Deposited,
        TwoHanded = scrap.TwoHanded,
        Expeditions = scrap.Expeditions
            .Select(e => new ExpeditionDTO { Id = e.Id, CrewNumber = e.CrewNumber, Moon = e.Moon, Notes = e.Notes, ExpeditionDate = e.ExpeditionDate })
            .ToList()
    };
}