using CiaTecnica_MVC.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace CiaTecnica_MVC.Models
{
    public class PessoaFisica
    {
        public int ID;

        [Required(ErrorMessage = "Digite o C.P.F.!")]
        [Display(Name = "CPF")]
        [DisplayFormat(DataFormatString = "{0:###.###-####-##}")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Digite a data de nascimento!")]
        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [MinAge(19)]
        public DateTime DataNasc { get; set; }

        [Required(ErrorMessage = "Digite o logradouro!")]
        [Display(Name = "Nome")]
        [StringLength(250, ErrorMessage = "Digite o nome com menos de 250 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o sobrenome!")]
        [Display(Name = "Sobrenome")]
        [StringLength(15, ErrorMessage = "Digite o sobrenome com menos de 15 caracteres.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Digite o C.E.P.!")]
        [Display(Name = "C.E.P.")]
        [StringLength(8, ErrorMessage = "Digite o sobrenome com menos de 15 caracteres.")]
        public string CEP { get; set; }

        public Endereco endereco;

    }
}