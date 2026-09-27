using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TecAdsTrabalhoPratico.Data;
using TecAdsTrabalhoPratico.Models;

namespace TecAdsTrabalhoPratico.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PagamentosController : ControllerBase
{
    private readonly TecAdsTrabalhoPraticoContext _context;

    public PagamentosController(TecAdsTrabalhoPraticoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pagamento>>> Get()
    {
        return await _context.Pagamentos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pagamento>> Get(int id)
    {
        var pagamento = await _context.Pagamentos.FindAsync(id);
        if (pagamento == null)
            return NotFound();
        return pagamento;
    }

    [HttpPost]
    public async Task<ActionResult<Pagamento>> Post(Pagamento pagamento)
    {
        _context.Pagamentos.Add(pagamento);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = pagamento.IdPagamento }, pagamento);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Pagamento pagamento)
    {
        if (id != pagamento.IdPagamento)
            return BadRequest();

        _context.Entry(pagamento).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var pagamento = await _context.Pagamentos.FindAsync(id);
        if (pagamento == null)
            return NotFound();

        _context.Pagamentos.Remove(pagamento);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
