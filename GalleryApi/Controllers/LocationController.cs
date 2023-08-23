using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GalleryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GalleryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly GalleryContext _context;

    public LocationController(GalleryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Location>>> Get()
    {
        return Ok(await _context.Locations.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Location>> Get(int id)
    {
        var location = await _context.Locations.FindAsync(id);
        if (location == null)
        {
            return NotFound("Локация не найдена");
        }
        return Ok(location);
    }

    [HttpPost]
    public async Task<ActionResult<List<Location>>> AddLocation(Location location)
    {
        _context.Locations.Add(location);
        await _context.SaveChangesAsync();
        return Ok(await _context.Locations.ToListAsync());
    }

    [HttpPut]
    public async Task<ActionResult<List<Location>>> UpdateLocation(Location location)
    {
        var DbLocation = await _context.Locations.FindAsync(location.Id);

        if (DbLocation == null)
        {
            return NotFound("Локация не найдена");
        }

        DbLocation.LocationName = location.LocationName;
        DbLocation.Geolocation = location.Geolocation;

        await _context.SaveChangesAsync();

        return Ok(await _context.Locations.ToListAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Location>>> DeleteLocation(int id)
    {
        var location = await _context.Locations.FindAsync(id);

        if (location == null)
        {
            return NotFound("Локация не найдена");
        }

        _context.Locations.Remove(location);
        await _context.SaveChangesAsync();

        return Ok(await _context.Locations.ToListAsync());
    }
}
