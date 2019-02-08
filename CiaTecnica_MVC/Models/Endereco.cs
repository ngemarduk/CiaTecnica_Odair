using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CiaTecnica_MVC.Models
{
    public class Endereco
    {
        public int IDEndereco { get; set; }

        [Required(ErrorMessage = "Digite o logradouro!")]
        [Display(Name = "Logradouro")]
        [StringLength(250, ErrorMessage = "Digite o logradouro com menos de 250 caracteres.")]
        public string Logradouro;

        [Required(ErrorMessage = "Digite o número!")]
        [Display(Name = "Número")]
        public int Numero;
        
        [Display(Name = "Complemento")]
        [StringLength(250, ErrorMessage = "Digite o complemento com menos de 250 caracteres.")]
        public string Complemento;

        [Required(ErrorMessage = "Digite a cidade!")]
        [Display(Name = "Cidade")]
        [StringLength(250, ErrorMessage = "Digite a cidade com menos de 250 caracteres.")]
        public string Cidade;

        [Required(ErrorMessage = "Digite o bairro!")]
        [Display(Name = "Bairro")]
        public string Bairro;

        [Required(ErrorMessage = "Digite o estado!")]
        [Display(Name = "UF")]
        [StringLength(2, ErrorMessage = "Digite o sobrenome com no máximo de 2.")]
        public string UFSigla;
        
        [Display(Name = "Estado")]
        [StringLength(8, ErrorMessage = "Digite o estado com no máximo 8 caracteres")]
        public string UFCompleto;

        [Required(ErrorMessage = "Digite o C.E.P.!")]
        [Display(Name = "C.E.P.")]
        [StringLength(250, ErrorMessage = "Digite o sobrenome com menos de 250 caracteres.")]
        public string CEP;

    }
}