using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TecAdsTrabalhoPratico.Data;
using TecAdsTrabalhoPratico.Models;

namespace TecAdsTrabalhoPratico.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VeiculosController : ControllerBase
{
    private readonly TecAdsTrabalhoPraticoContext _context;

    public VeiculosController(TecAdsTrabalhoPraticoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Veiculo>>> Get()
    {
        return await _context.Veiculos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Veiculo>> Get(int id)
    {
        var veiculo = await _context.Veiculos.FindAsync(id);
        if (veiculo == null)
            return NotFound();
        return veiculo;
    }

    [HttpPost]
    public async Task<ActionResult<Veiculo>> Post(Veiculo veiculo)
    {
        _context.Veiculos.Add(veiculo);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = veiculo.IdVeiculo }, veiculo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Veiculo veiculo)
    {
        if (id != veiculo.IdVeiculo)
            return BadRequest();

        _context.Entry(veiculo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var veiculo = await _context.Veiculos.FindAsync(id);
        if (veiculo == null)
            return NotFound();

        _context.Veiculos.Remove(veiculo);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
