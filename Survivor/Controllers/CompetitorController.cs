using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survivor.Entites;

[Route("api/[controller]")]
[ApiController]
public class CompetitorController : ControllerBase
{
    private readonly PatikaDbContext _context;

    public CompetitorController(PatikaDbContext context)
    {
        _context = context;
    }

    // GET /api/competitors
    [HttpGet]
    public async Task<IActionResult> GetCompetitors()
    {
        var competitors = await _context.Competitors.ToListAsync();
        return Ok(competitors);
    }

    // GET /api/competitors/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompetitorById(int id)
    {
        var competitor = await _context.Competitors.FindAsync(id);
        if (competitor == null)
        {
            return NotFound();
        }
        return Ok(competitor);
    }

    // GET /api/competitors/categories/{CategoryId}
    [HttpGet("categories/{categoryId}")]
    public async Task<IActionResult> GetCompetitorsByCategory(int categoryId)
    {
        var competitors = await _context.Competitors.Where(c => c.CategoryId == categoryId).ToListAsync();
        return Ok(competitors);
    }

    // POST /api/competitors
    [HttpPost]
    public async Task<IActionResult> CreateCompetitor(Competitor competitor)
    {
        _context.Competitors.Add(competitor);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCompetitorById), new { id = competitor.Id }, competitor);
    }

    // PUT /api/competitors/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompetitor(int id, Competitor updatedCompetitor)
    {
        var competitor = await _context.Competitors.FindAsync(id);
        if (competitor == null)
        {
            return NotFound();
        }

        competitor.FirstName = updatedCompetitor.FirstName;
        competitor.LastName = updatedCompetitor.LastName;
        competitor.CategoryId = updatedCompetitor.CategoryId;
        competitor.ModifiedDate = DateTime.Now;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE /api/competitors/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompetitor(int id)
    {
        var competitor = await _context.Competitors.FindAsync(id);
        if (competitor == null)
        {
            return NotFound();
        }

        _context.Competitors.Remove(competitor);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
