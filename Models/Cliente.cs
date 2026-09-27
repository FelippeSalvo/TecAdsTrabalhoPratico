using System.ComponentModel.DataAnnotations;

namespace TecAdsTrabalhoPratico.Models;

public class Cliente
{
    [Key]
    public int IdCliente { get; set; }

    [Required]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public string Cpf { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public string? Telefone { get; set; }

    public string? Endereco { get; set; }

    public ICollection<Aluguel> Alugueis { get; set; } = new List<Aluguel>();
}
