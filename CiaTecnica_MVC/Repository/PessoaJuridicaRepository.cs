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
    public class PessoaJuridicaRepository: IPessoaJuridicaRepository
    {
        /// <summary>
        /// Cadastra o nova pessoa jurídica
        /// </summary>
        /// <param name="pessoaJuridica"> Dados da pessoa jurídica a ser cadastrada</param>
        /// <returns></returns>
        public int Inserir(PessoaJuridica pessoaJuridica)
        {
            int retorno = 0;

            try
            {
				List<OracleParameter> lstParametros = new List<OracleParameter>();
				
				BancoHelper objBanco = new BancoHelper();
				OracleDataReader reader;
				
				lstParametros.Add(new OracleParameter("CNPJ", OracleDbType.Varchar2) { Value = pessoaJuridica.CNPJ });
				lstParametros.Add(new OracleParameter("NomeFantasia", OracleDbType.Varchar2) { Value = pessoaJuridica.NomeFantasia });
				lstParametros.Add(new OracleParameter("RazaoSocial", OracleDbType.Varchar2) { Value = pessoaJuridica.RazaoSocial });
				
				
				lstParametros.Add(new OracleParameter("Logradouro", OracleDbType.Varchar2) { Value = pessoaJuridica.endereco.Logradouro });
				lstParametros.Add(new OracleParameter("Numero", OracleDbType.Varchar2) { Value = pessoaJuridica.endereco.Numero });
				lstParametros.Add(new OracleParameter("Complemento", OracleDbType.Varchar2) { Value = pessoaJuridica.endereco.Complemento });
                lstParametros.Add(new OracleParameter("Bairro", OracleDbType.Varchar2) { Value = pessoaJuridica.endereco.Bairro });
                lstParametros.Add(new OracleParameter("Cidade", OracleDbType.Varchar2) { Value = pessoaJuridica.endereco.Cidade });
                lstParametros.Add(new OracleParameter("UFSigla", OracleDbType.Varchar2) { Value = pessoaJuridica.endereco.UFSigla });
				lstParametros.Add(new OracleParameter("UFCompleto", OracleDbType.Varchar2) { Value = pessoaJuridica.endereco.UFCompleto });
				lstParametros.Add(new OracleParameter("CEP", OracleDbType.Varchar2) { Value = pessoaJuridica.endereco.CEP });

                reader = objBanco.ProcedureExecute("PESSOA_JURIDICA_CADASTRA", lstParametros);

                if (reader != null)
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            retorno = (int)reader["retorno"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro - Pessoa jurídica: Cadastra - Mensagem:" + ex.Message + " - Exeção: " + ex.InnerException);
            }

            return retorno;
        }

        /// <summary>
        /// Alteração dos dados da pessoa física
        /// </summary>
        /// <param name="pessoaJuridica">Dados da pessoa jurídica a ser alterada</param>
        /// <returns></returns>
        public int Alterar(PessoaJuridica pessoaJuridica)
        {
            int retorno = 0;

            try
            {
                List<OracleParameter> lstParametros = new List<OracleParameter>();

                BancoHelper objBanco = new BancoHelper();
                OracleDataReader reader;

                lstParametros.Add(new OracleParameter("CNPJ", OracleDbType.Varchar2) { Value = pessoaJuridica.CNPJ });
                lstParametros.Add(new OracleParameter("NomeFantasia", OracleDbType.Varchar2) { Value = pessoaJuridica.NomeFantasia });
                lstParametros.Add(new OracleParameter("RazaoSocial", OracleDbType.Varchar2) { Value = pessoaJuridica.RazaoSocial });


                lstParametros.Add(new OracleParameter("Logradouro", OracleDbType.Varchar2) { Value = pessoaJuridica.endereco.Logradouro });
                lstParametros.Add(new OracleParameter("Numero", OracleDbType.Varchar2) { Value = pessoaJuridica.endereco.Numero });
                lstParametros.Add(new OracleParameter("Complemento", OracleDbType.Varchar2) { Value = pessoaJuridica.endereco.Complemento });
                lstParametros.Add(new OracleParameter("Bairro", OracleDbType.Varchar2) { Value = pessoaJuridica.endereco.Bairro });
                lstParametros.Add(new OracleParameter("Cidade", OracleDbType.Varchar2) { Value = pessoaJuridica.endereco.Cidade });
                lstParametros.Add(new OracleParameter("UFSigla", OracleDbType.Varchar2) { Value = pessoaJuridica.endereco.UFSigla });
                lstParametros.Add(new OracleParameter("UFCompleto", OracleDbType.Varchar2) { Value = pessoaJuridica.endereco.UFCompleto });
                lstParametros.Add(new OracleParameter("CEP", OracleDbType.Varchar2) { Value = pessoaJuridica.endereco.CEP });

                reader = objBanco.ProcedureExecute("PESSOA_JURIDICA_ALTERA", lstParametros);

                if (reader != null)
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            retorno = (int)reader["retorno"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Erro - Pessoa jurídica: Alterar - Mensagem:" + ex.Message + " - Exeção: " + ex.InnerException);
            }

            return retorno;
        }

        /// <summary>
        /// Apaga o a pessoa física selecionada
        /// </summary>
        /// <param name="idPJ">id da pessoa jurídica selecionada</param>
        /// <returns></returns>
        public int Apagar(int idPJ)
        {
            int retorno = 0;
            
            try
            {
                List<OracleParameter> lstParametros = new List<OracleParameter>();

                BancoHelper objBanco = new BancoHelper();
                OracleDataReader reader;

                lstParametros.Add(new OracleParameter("ID", OracleDbType.Int32) { Value = idPJ });

                reader = objBanco.ProcedureExecute("PESSOA_JURIDICA_APAGA", lstParametros);

                if(reader != null)
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            if ((int)reader["retorno"] == 1)
                            {
                                retorno = 1;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Erro - Pessoa jurídica: Apagar - Mensagem:" + ex.Message + " - Exeção: " + ex.InnerException);
            }

            return retorno;

        }

        /// <summary>
        /// Dados do produto selecionado
        /// </summary>
        /// <param name="idPJ">id do Pessoa Física</param>
        /// <returns>objeto da pessoa física contendo os dados do id selecionado</returns>
        public PessoaJuridica Dados(int idPJ)
        {
            
            try
            {
                PessoaJuridica pessoaJuridica = null;
                List<OracleParameter> lstParametros = new List<OracleParameter>();

                BancoHelper objBanco = new BancoHelper();
                OracleDataReader reader;

                lstParametros.Add(new OracleParameter("ID", OracleDbType.Int32) { Value = idPJ });

                reader = objBanco.ProcedureExecute("PESSOA_JURIDICA_DADOS", lstParametros);

                if(reader != null)
                {
                    if (reader.Read())
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
                    }
                }

                return pessoaJuridica;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro - Pessoa Jurídica: Dados - Mensagem:" + ex.Message + " - Exeção: " + ex.InnerException);
                return null;
            }
            
        }

        /// <summary>
        /// Lista de pessoas jurídicas cadastradas
        /// </summary>
        /// <returns>Objeto lista com as pessoas jurídicas cadastrados</returns>
        public IEnumerable<PessoaJuridica> ListaTodos()
        {
            try
            {
                PessoaJuridica pessoaJuridica = null;

                List<PessoaJuridica> list = new List<PessoaJuridica>();
                List<OracleParameter> lstParametros = new List<OracleParameter>();

                BancoHelper objBanco = new BancoHelper();
                OracleDataReader reader;
                
                reader = objBanco.ProcedureExecute("PESSOA_JURIDICA_LISTA", lstParametros);

                if(reader != null)
                {
                    while (reader.Read())
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

                        list.Add(pessoaJuridica);
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

        /// <summary>
        /// Lista os produtos da pesquisa
        /// </summary>
        /// <param name="pesquisa">String com a pesquisa a ser feita, no nome ou descrição do produto</param>
        /// <returns>Lista de produtos com relação a pesquisa</returns>
        public IEnumerable<PessoaJuridica> ListaPesquisa(string pesquisa)
        {
            
            try
            {

                PessoaJuridica pessoaJuridica = null;

                List<PessoaJuridica> list = new List<PessoaJuridica>();
                List<OracleParameter> lstParametros = new List<OracleParameter>();

                lstParametros.Add(new OracleParameter("pesquisa", OracleDbType.Varchar2) { Value = pesquisa });

                BancoHelper objBanco = new BancoHelper();
                OracleDataReader reader;

                reader = objBanco.ProcedureExecute("PESSOA_JURIDICA_PESQUISA", lstParametros);

                if (reader != null)
                {
                    while (reader.Read())
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

                        list.Add(pessoaJuridica);
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro - Pessoa Jurídica: ListaPesquisa - Mensagem:" + ex.Message + " - Exeção: " + ex.InnerException);

                return null;
            }

            
        }
    }
}