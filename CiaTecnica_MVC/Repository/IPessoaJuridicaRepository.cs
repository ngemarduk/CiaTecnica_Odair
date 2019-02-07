using CiaTecnica_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CiaTecnica_MVC.Repository
{
    public interface IPessoaJuridicaRepository
    {
        int Inserir(PessoaJuridica pessoaJuridica);
        int Alterar(PessoaJuridica pessoaJuridica);
        int Apagar(int idPF);
        PessoaJuridica Dados(int idPF);
        IEnumerable<PessoaJuridica> ListaTodos();
        IEnumerable<PessoaJuridica> ListaPesquisa(string pesquisa);
    }
}