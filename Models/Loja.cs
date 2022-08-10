using System.ComponentModel.DataAnnotations;
namespace back.Models
{
    public class Loja{
        public int LojaId {get;set;}
        public DateTime Data {get;set;}
        [Required]
        public String Nome {get;set;}
        [Required]
        public String Telefone {get;set;}
        [Required]
        [EmailAddress]
        public String Email {get;set;}
        [Required]
        public String Cep {get;set;}
        public ICollection<Fornecedor> Fornecedores {get;set;}
        public ICollection<Cliente> Clientes {get;set;}
    }
    
}