using CiaTecnica_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiaTecnica_MVC.Repository
{
    public interface IPessoaFisicaRepository
    {
        int Inserir(PessoaFisica pessoaFisica);
        int Alterar(PessoaFisica pessoaFisica);
        int Apagar(int idPF);
        PessoaFisica Dados(int idPF);
        IEnumerable<PessoaFisica> ListaTodos();
        IEnumerable<PessoaFisica> ListaPesquisa(string pesquisa);
    }
}