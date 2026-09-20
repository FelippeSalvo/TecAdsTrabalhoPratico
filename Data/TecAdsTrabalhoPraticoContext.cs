using TecAdsTrabalhoPratico.Models;
using Microsoft.EntityFrameworkCore;

namespace TecAdsTrabalhoPratico.Data;

public class TecAdsTrabalhoPraticoContext : DbContext
{
    public TecAdsTrabalhoPraticoContext(DbContextOptions<TecAdsTrabalhoPraticoContext> options)
        : base(options)
    {
    }

    public DbSet<Fabricante> Fabricantes { get; set; }

    public DbSet<Veiculo> Veiculos { get; set; }

    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Aluguel> Alugueis { get; set; }

    public DbSet<Pagamento> Pagamentos { get; set; }
}