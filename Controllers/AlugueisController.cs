using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TecAdsTrabalhoPratico.Data;
using TecAdsTrabalhoPratico.Models;

namespace TecAdsTrabalhoPratico.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlugueisController : ControllerBase
{
    private readonly TecAdsTrabalhoPraticoContext _context;

    public AlugueisController(TecAdsTrabalhoPraticoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Aluguel>>> Get()
    {
        return await _context.Alugueis.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Aluguel>> Get(int id)
    {
        var aluguel = await _context.Alugueis.FindAsync(id);
        if (aluguel == null)
            return NotFound();
        return aluguel;
    }

    [HttpPost]
    public async Task<ActionResult<Aluguel>> Post(Aluguel aluguel)
    {
        _context.Alugueis.Add(aluguel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = aluguel.IdAluguel }, aluguel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Aluguel aluguel)
    {
        if (id != aluguel.IdAluguel)
            return BadRequest();

        _context.Entry(aluguel).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var aluguel = await _context.Alugueis.FindAsync(id);
        if (aluguel == null)
            return NotFound();

        _context.Alugueis.Remove(aluguel);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
