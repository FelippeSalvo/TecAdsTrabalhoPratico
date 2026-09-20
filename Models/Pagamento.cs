using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecAdsTrabalhoPratico.Models;

public class Pagamento
{
    [Key]
    public int IdPagamento { get; set; }

    public int IdAluguel { get; set; }

    public decimal Valor { get; set; }

    public DateTime DataPagamento { get; set; }

    public string FormaPagamento { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    [ForeignKey(nameof(IdAluguel))]
    public Aluguel Aluguel { get; set; } = null!;
}