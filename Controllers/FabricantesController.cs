using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TecAdsTrabalhoPratico.Data;
using TecAdsTrabalhoPratico.Models;

namespace TecAdsTrabalhoPratico.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FabricantesController : ControllerBase
{
    private readonly TecAdsTrabalhoPraticoContext _context;

    public FabricantesController(TecAdsTrabalhoPraticoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Fabricante>>> Get()
    {
        return await _context.Fabricantes.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Fabricante>> Get(int id)
    {
        var fabricante = await _context.Fabricantes.FindAsync(id);
        if (fabricante == null)
            return NotFound();
        return fabricante;
    }

    [HttpPost]
    public async Task<ActionResult<Fabricante>> Post(Fabricante fabricante)
    {
        _context.Fabricantes.Add(fabricante);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = fabricante.IdFabricante }, fabricante);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Fabricante fabricante)
    {
        if (id != fabricante.IdFabricante)
            return BadRequest();

        _context.Entry(fabricante).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var fabricante = await _context.Fabricantes.FindAsync(id);
        if (fabricante == null)
            return NotFound();

        _context.Fabricantes.Remove(fabricante);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
