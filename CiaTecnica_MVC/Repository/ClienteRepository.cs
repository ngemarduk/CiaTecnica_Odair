using CiaTecnica_MVC.Helper;
using CiaTecnica_MVC.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace CiaTecnica_MVC.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public List<PessoaFisicaJuridica> ListaTodos()
        {
            try
            {
                PessoaJuridica pessoaJuridica = null;
                PessoaFisica pessoaFisica = null;
                PessoaFisicaJuridica pessoaFisicaJuridica = null;

                List<PessoaFisicaJuridica> list = new List<PessoaFisicaJuridica>();
                List<OracleParameter> lstParametros = new List<OracleParameter>();

                BancoHelper objBanco = new BancoHelper();
                OracleDataReader reader;

                reader = objBanco.ProcedureExecute("PESSOA_JURIDICA_LISTA", lstParametros);

                if (reader != null)
                {
                    while (reader.Read())
                    {

                        pessoaFisicaJuridica = new PessoaFisicaJuridica();

                        if (reader["CNPJ"] != null)
                        { 
                            pessoaJuridica = new PessoaJuridica();
                            pessoaJuridica.ID = (int)reader["id"];
                            pessoaJuridica.CNPJ = reader["CNPJ"].ToString();
                            pessoaJuridica.NomeFantasia = reader["NomeFantasia"].ToString();
                            pessoaJuridica.RazaoSocial = reader["RazaoSocial"].ToString();

                            pessoaJuridica.endereco.Logradouro = reader["Logradouro"].ToString();
                            pessoaJuridica.endereco.Numero = (int)reader["Numero"];
                            pessoaJuridica.endereco.Complemento = reader["Complemento"].ToString();
                            pessoaJuridica.endereco.Bairro = reader["Bairro"].ToString();
                            pessoaJuridica.endereco.Cidade = reader["Cidade"].ToString();
                            pessoaJuridica.endereco.UFCompleto = reader["UFCompleto"].ToString();

                            pessoaFisicaJuridica.pessoaJuridica = pessoaJuridica;
                        }
                        else { 

                            pessoaFisica = new PessoaFisica();
                            pessoaFisica.ID = (int)reader["id"];
                            pessoaFisica.CPF = reader["CPF"].ToString();
                            pessoaFisica.Nome = reader["Nome"].ToString();
                            pessoaFisica.Sobrenome = reader["Sobrenome"].ToString();

                            if (reader["DataNasc"] != DBNull.Value)
                                pessoaFisica.DataNasc = (DateTime)reader["DataNasc"];

                            pessoaFisica.endereco.Logradouro = reader["Logradouro"].ToString();
                            pessoaFisica.endereco.Numero = (int)reader["Numero"];
                            pessoaFisica.endereco.Complemento = reader["Complemento"].ToString();
                            pessoaFisica.endereco.Bairro = reader["Bairro"].ToString();
                            pessoaFisica.endereco.Cidade = reader["Cidade"].ToString();
                            pessoaFisica.endereco.UFCompleto = reader["UFCompleto"].ToString();

                            pessoaFisicaJuridica.pessoaFisica = pessoaFisica;
                        }
                        list.Add(pessoaFisicaJuridica);
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro - Pessoa Jurídica: Lista - Mensagem:" + ex.Message + " - Exeção: " + ex.InnerException);

                return null;
            }
        }
    }
}