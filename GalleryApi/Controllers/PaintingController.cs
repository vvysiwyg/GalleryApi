using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GalleryApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;
using Npgsql;

namespace GalleryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaintingController : ControllerBase
{
    private readonly GalleryContext _context;

    public PaintingController(GalleryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Painting>>> Get()
    {
        return Ok(await _context.Paintings.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Painting>> Get(int id)
    {
        var painting = await _context.Paintings.FindAsync(id);
        if (painting == null)
        {
            return NotFound("Картина не найдена");
        }
        return Ok(painting);
    }

    [HttpPost]
    public async Task<ActionResult<List<Painting>>> AddPainting(Painting painting)
    {
        string param = "Default string";
        try
        {
            _context.Paintings.Add(painting);
            await _context.SaveChangesAsync();
            return Ok(await _context.Paintings.ToListAsync());
        }
        catch (DbUpdateException ex) when (ex.InnerException is PostgresException) 
        {
            param = ex.InnerException.Message;
        }
        return new ISE(param);
    }

    [HttpPut]
    public async Task<ActionResult<List<Painting>>> UpdatePainting(Painting painting)
    {
        var DbPainting = await _context.Paintings.FindAsync(painting.Id);

        if (DbPainting == null)
        {
            return NotFound("Картина не найдена");
        }

        DbPainting.PaintingName = painting.PaintingName;
        DbPainting.DateOfCreation = painting.DateOfCreation;
        DbPainting.Size = painting.Size;
        DbPainting.Genre = painting.Genre;
        DbPainting.AuthorId = painting.AuthorId;
        DbPainting.LocationId = painting.LocationId;

        await _context.SaveChangesAsync();

        return Ok(await _context.Paintings.ToListAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Painting>>> DeletePainting(int id)
    {
        var painting = await _context.Paintings.FindAsync(id);

        if (painting == null)
        {
            return NotFound("Картина не найдена");
        }

        _context.Paintings.Remove(painting);
        await _context.SaveChangesAsync();

        return Ok(await _context.Paintings.ToListAsync());
    }
}
