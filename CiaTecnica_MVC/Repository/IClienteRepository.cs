using CiaTecnica_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiaTecnica_MVC.Repository
{
    public interface IClienteRepository
    {
        List<PessoaFisicaJuridica> ListaTodos();
    }
}