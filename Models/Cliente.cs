using System.ComponentModel.DataAnnotations;

namespace TecAdsTrabalhoPratico.Models;

public class Cliente
{
    [Key]
    public int IdCliente { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Cpf { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? Telefone { get; set; }

    public string? Endereco { get; set; }

    public ICollection<Aluguel> Alugueis { get; set; } = new List<Aluguel>();
}