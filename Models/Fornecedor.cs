using System.ComponentModel.DataAnnotations;

namespace back.Models
{
    public class Fornecedor
    {

        public int Id {get;set;}
        [Required]
        public string Nome {get;set;}
        [Required]
        public string RazaoSocial {get;set;}
        [Required]
        public string Telefone {get;set;}
        [Required]
        [EmailAddress]
        public string Email {get;set;}
        [Required]
        public string Cpf {get;set;}
        [Required]
        public string Cnpj {get;set;}
        [Required]
        public string Empresa {get;set;}
        [Required]
        public string Cep {get;set;}
        [Required]
        public string Observacao {get;set;}
        [Required]
        public int LojaId { get; set; }
        public Loja Loja { get; set; }




    }

}