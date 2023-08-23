using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using GalleryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GalleryApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly GalleryContext _context; 

    public AuthorController(GalleryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Author>>> Get()
    {
        return Ok(await _context.Authors.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Author>> Get(int id)
    {
        var author = await _context.Authors.FindAsync(id);
        if(author == null) 
        {
            return NotFound("Автор не найден");
        }
        return Ok(author);
    }

    [HttpPost]
    public async Task<ActionResult<List<Author>>> AddAuthor(Author author)
    {
        _context.Authors.Add(author);
        await _context.SaveChangesAsync();
        return Ok(await _context.Authors.ToListAsync());
    }

    [HttpPut]
    public async Task<ActionResult<List<Author>>> UpdateAuthor(Author author)
    {
        var DbAuthor = await _context.Authors.FindAsync(author.Id);

        if(DbAuthor == null) 
        {
            return NotFound("Автор не найден");
        }

        DbAuthor.AuthorName = author.AuthorName;
        DbAuthor.PlaceOfBirth = author.PlaceOfBirth;
        DbAuthor.PlaceOfStudy = author.PlaceOfStudy;
        DbAuthor.Dob = author.Dob;

        await _context.SaveChangesAsync();

        return Ok(await _context.Authors.ToListAsync());  
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<Author>>> DeleteAuthor(int id)
    {
        var author = await _context.Authors.FindAsync(id);

        if(author == null)
        {
            return NotFound("Автор не найден");
        }

        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();

        return Ok(await _context.Authors.ToListAsync());
    }
}
