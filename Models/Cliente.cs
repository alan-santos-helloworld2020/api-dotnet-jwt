namespace back.Models;
using System.ComponentModel.DataAnnotations;

public class Cliente
{
    public int Id { get; set; }
    [Required]
    public DateTime Data { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Telefone { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Cep { get; set; }
}

