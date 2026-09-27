using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TecAdsTrabalhoPratico.Models;

public class Veiculo
{
    [Key]
    public int IdVeiculo { get; set; }

    public int IdFabricante { get; set; }

    [Required]
    public string Modelo { get; set; } = string.Empty;

    [Range(1900, 2100)]
    public int AnoFabricacao { get; set; }

    [Range(0, int.MaxValue)]
    public int Quilometragem { get; set; }

    [Required]
    public string Status { get; set; } = string.Empty;

    [ForeignKey(nameof(IdFabricante))]
    public Fabricante? Fabricante { get; set; }

    public ICollection<Aluguel> Alugueis { get; set; } = new List<Aluguel>();
}
