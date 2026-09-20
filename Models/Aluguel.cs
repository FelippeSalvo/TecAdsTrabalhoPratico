using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecAdsTrabalhoPratico.Models;

public class Aluguel
{
    [Key]
    public int IdAluguel { get; set; }

    public int IdCliente { get; set; }

    public int IdVeiculo { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    public DateTime? DataDevolucao { get; set; }

    public int QuilometragemInicial { get; set; }

    public int? QuilometragemFinal { get; set; }

    public decimal ValorDiaria { get; set; }

    public decimal ValorTotal { get; set; }

    [ForeignKey(nameof(IdCliente))]
    public Cliente Cliente { get; set; } = null!;

    [ForeignKey(nameof(IdVeiculo))]
    public Veiculo Veiculo { get; set; } = null!;

    public ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
}