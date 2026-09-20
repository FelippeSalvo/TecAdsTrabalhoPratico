using System.ComponentModel.DataAnnotations;

namespace TecAdsTrabalhoPratico.Models;

public class Fabricante
{
    [Key]
    public int IdFabricante { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string? Descricao { get; set; }

    public string? Pais { get; set; }

    public ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}