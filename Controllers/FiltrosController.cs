using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TecAdsTrabalhoPratico.Data;

namespace TecAdsTrabalhoPratico.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FiltrosController : ControllerBase
{
    private readonly TecAdsTrabalhoPraticoContext _context;

    public FiltrosController(TecAdsTrabalhoPraticoContext context)
    {
        _context = context;
    }

    [HttpGet("veiculos-por-fabricante")]
    public async Task<IActionResult> VeiculosPorFabricante(string? fabricante)
    {
        var query =
            from v in _context.Veiculos
            join f in _context.Fabricantes on v.IdFabricante equals f.IdFabricante
            select new { v.IdVeiculo, v.Modelo, v.AnoFabricacao, v.Status, Fabricante = f.Nome };

        if (!string.IsNullOrWhiteSpace(fabricante))
            query = query.Where(x => x.Fabricante.Contains(fabricante));

        return Ok(await query.ToListAsync());
    }

    [HttpGet("alugueis-detalhados")]
    public async Task<IActionResult> AlugueisDetalhados()
    {
        var query =
            from a in _context.Alugueis
            join c in _context.Clientes on a.IdCliente equals c.IdCliente
            join v in _context.Veiculos on a.IdVeiculo equals v.IdVeiculo
            select new { a.IdAluguel, Cliente = c.Nome, Veiculo = v.Modelo, a.DataInicio, a.DataFim, a.ValorTotal };

        return Ok(await query.ToListAsync());
    }

    [HttpGet("pagamentos-por-status")]
    public async Task<IActionResult> PagamentosPorStatus(string? status)
    {
        var query =
            from p in _context.Pagamentos
            join a in _context.Alugueis on p.IdAluguel equals a.IdAluguel
            join c in _context.Clientes on a.IdCliente equals c.IdCliente
            select new { p.IdPagamento, p.Valor, p.DataPagamento, p.FormaPagamento, p.Status, Cliente = c.Nome };

        if (!string.IsNullOrWhiteSpace(status))
            query = query.Where(x => x.Status == status);

        return Ok(await query.ToListAsync());
    }

    [HttpGet("clientes-com-total-alugueis")]
    public async Task<IActionResult> ClientesComTotalAlugueis()
    {
        var query =
            from c in _context.Clientes
            join a in _context.Alugueis on c.IdCliente equals a.IdCliente into grupo
            select new { c.IdCliente, c.Nome, TotalAlugueis = grupo.Count() };

        return Ok(await query.ToListAsync());
    }

    [HttpGet("fabricantes-com-total-veiculos")]
    public async Task<IActionResult> FabricantesComTotalVeiculos()
    {
        var query =
            from f in _context.Fabricantes
            join v in _context.Veiculos on f.IdFabricante equals v.IdFabricante into grupo
            select new { f.IdFabricante, f.Nome, TotalVeiculos = grupo.Count() };

        return Ok(await query.ToListAsync());
    }
}
