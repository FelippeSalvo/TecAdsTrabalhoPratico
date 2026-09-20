using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecAdsTrabalhoPratico.Models;

public class Veiculo
{
    [Key]
    public int IdVeiculo { get; set; }

    public int IdFabricante { get; set; }

    public string Modelo { get; set; } = string.Empty;

    public int AnoFabricacao { get; set; }

    public int Quilometragem { get; set; }

    public string Status { get; set; } = string.Empty;

    [ForeignKey(nameof(IdFabricante))]
    public Fabricante Fabricante { get; set; } = null!;

    public ICollection<Aluguel> Alugueis { get; set; } = new List<Aluguel>();
}