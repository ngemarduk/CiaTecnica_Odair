using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiaTecnica_MVC.Models
{
    public class PessoaFisicaJuridica
    {
        public PessoaFisica pessoaFisica { get; set;}
        public PessoaJuridica pessoaJuridica { get; set; }
    }
}