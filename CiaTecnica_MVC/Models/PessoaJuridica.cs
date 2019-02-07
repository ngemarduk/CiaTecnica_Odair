using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CiaTecnica_MVC.Models
{
    public class PessoaJuridica
    {
        public int ID {get; set;}

        [Required(ErrorMessage = "Digite o C.N.P.J.!")]
        [Display(Name = "CNPJ")]
        [DisplayFormat(DataFormatString = "{0:##.###-####/####-##}")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Digite a razão Social!")]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Digite o nome fantasia!")]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Digite o C.E.P.!")]
        [Display(Name = "C.E.P.")]
        [StringLength(8, ErrorMessage = "Digite o sobrenome com menos de 15 caracteres.")]
        public string CEP { get; set; }

        public Endereco endereco { get; set; }
    }
}