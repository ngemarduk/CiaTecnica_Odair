using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using CiaTecnica_MVC.Models;
using CiaTecnica_MVC.Helper;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace CiaTecnica_MVC.Repository
{
    public class PessoaFisicaRepository: IPessoaFisicaRepository
    {
        /// <summary>
        /// Cadastra o nova pessoa física
        /// </summary>
        /// <param name="pessoaFisica"> Dados da pessoa física a ser cadastrada</param>
        /// <returns></returns>
        public int Inserir(PessoaFisica pessoaFisica)
        {
			int retorno = 0;
			
			try
            {
				List<OracleParameter> lstParametros = new List<OracleParameter>();

                BancoHelper objBanco = new BancoHelper();
				OracleDataReader dr;
				
				lstParametros.Add(new OracleParameter("CPF", OracleDbType.Varchar2) { Value = pessoaFisica.CPF });
				lstParametros.Add(new OracleParameter("DataNasc", OracleDbType.Varchar2) { Value = pessoaFisica.DataNasc });
				lstParametros.Add(new OracleParameter("Nome", OracleDbType.Varchar2) { Value = pessoaFisica.Nome });
				lstParametros.Add(new OracleParameter("Sobrenome", OracleDbType.Varchar2) { Value = pessoaFisica.Sobrenome });
				lstParametros.Add(new OracleParameter("CPF", OracleDbType.Varchar2) { Value = pessoaFisica.CPF });

                lstParametros.Add(new OracleParameter("Logradouro", OracleDbType.Varchar2) { Value = pessoaFisica.endereco.Logradouro });
                lstParametros.Add(new OracleParameter("Numero", OracleDbType.Varchar2) { Value = pessoaFisica.endereco.Numero });
                lstParametros.Add(new OracleParameter("Complemento", OracleDbType.Varchar2) { Value = pessoaFisica.endereco.Complemento });
                lstParametros.Add(new OracleParameter("UFSigla", OracleDbType.Varchar2) { Value = pessoaFisica.endereco.UFSigla });
                lstParametros.Add(new OracleParameter("UFCompleto", OracleDbType.Varchar2) { Value = pessoaFisica.endereco.UFCompleto });
                lstParametros.Add(new OracleParameter("CEP", OracleDbType.Varchar2) { Value = pessoaFisica.endereco.CEP });

                dr = objBanco.ProcedureExecute("PESSOA_FISICA_CADASTRA", lstParametros);
			
				if (dr.HasRows)
				{
					if (dr.Read())
					{
						retorno = (int)dr["retorno"];
					}
				}
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro - Pessoa Física: Cadastra - Mensagem:" + ex.Message + " - Exeção: " + ex.InnerException);
            }

            return retorno;
        }

        /// <summary>
        /// Alteração dos dados da pessoa física
        /// </summary>
        /// <param name="pessoaFisica">Dados da pessoa física a ser alterada</param>
        /// <returns></returns>
        public int Alterar(PessoaFisica pessoaFisica)
        {
			
            try
            {
				int retorno = 0;
				
				OracleDataReader dr;

				List<OracleParameter> lstParametros = new List<OracleParameter>();

                BancoHelper objBanco = new BancoHelper();
				DataTable dtData = new DataTable();
			
				lstParametros.Add(new OracleParameter("ID", OracleDbType.Varchar2) { Value = pessoaFisica.ID });
				lstParametros.Add(new OracleParameter("CPF", OracleDbType.Varchar2) { Value = pessoaFisica.CPF });
				lstParametros.Add(new OracleParameter("DataNasc", OracleDbType.Varchar2) { Value = pessoaFisica.DataNasc });
				lstParametros.Add(new OracleParameter("Nome", OracleDbType.Varchar2) { Value = pessoaFisica.Nome });
				lstParametros.Add(new OracleParameter("Sobrenome", OracleDbType.Varchar2) { Value = pessoaFisica.Sobrenome });
				lstParametros.Add(new OracleParameter("CPF", OracleDbType.Varchar2) { Value = pessoaFisica.CPF });
				
				lstParametros.Add(new OracleParameter("Logradouro", OracleDbType.Varchar2) { Value = pessoaFisica.endereco.Logradouro });
				lstParametros.Add(new OracleParameter("Numero", OracleDbType.Varchar2) { Value = pessoaFisica.endereco.Numero });
				lstParametros.Add(new OracleParameter("Complemento", OracleDbType.Varchar2) { Value = pessoaFisica.endereco.Complemento });
				lstParametros.Add(new OracleParameter("UFSigla", OracleDbType.Varchar2) { Value = pessoaFisica.endereco.UFSigla });
				lstParametros.Add(new OracleParameter("UFCompleto", OracleDbType.Varchar2) { Value = pessoaFisica.endereco.UFCompleto });
				lstParametros.Add(new OracleParameter("CEP", OracleDbType.Varchar2) { Value = pessoaFisica.endereco.CEP });
				
				dr = objBanco.ProcedureExecute("PESSOA_FISICA_ALTERA", lstParametros);

                return retorno;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro - Pessoa Física: Alterar - Mensagem:" + ex.Message + " - Exeção: " + ex.InnerException);

                return 0;
            }
            
        }

        /// <summary>
        /// Apaga o a pessoa física selecionada
        /// </summary>
        /// <param name="idPF">id da pessoa física selecionada</param>
        /// <returns></returns>
        public int Apagar(int idPF)
        {
            int retorno = 0;

            try
            {
				List<OracleParameter> lstParametros = new List<OracleParameter>();

                BancoHelper objBanco = new BancoHelper();
				
				OracleDataReader reader;
				
				lstParametros.Add(new OracleParameter("ID", OracleDbType.Int32) { Value = idPF });
				
				reader = objBanco.ProcedureExecute("PESSOA_FISICA_APAGA", lstParametros);
				
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Erro - Pessoa Física: Apagar - Mensagem:" + ex.Message + " - Exeção: " + ex.InnerException);
            }

            return retorno;

        }

        /// <summary>
        /// Dados do produto selecionado
        /// </summary>
        /// <param name="idPF">id do Pessoa Física</param>
        /// <returns>objeto da pessoa física contendo os dados do id selecionado</returns>
        public PessoaFisica Dados(int idPF)
        {
            try
            {
                PessoaFisica pessoaFisica = null;

                List<OracleParameter> lstParametros = new List<OracleParameter>();

                BancoHelper objBanco = new BancoHelper();
				
				OracleDataReader reader;
				
				lstParametros.Add(new OracleParameter("ID", OracleDbType.Int32) { Value = idPF });
				
				reader = objBanco.ProcedureExecute("PESSOA_FISICA_DADOS", lstParametros);
				
				if (reader.Read())
				{
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
                }

                return pessoaFisica;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Erro - Pessoa Física: Dados - Mensagem:" + ex.Message + " - Exeção: " + ex.InnerException);
                return null;
            }
            
        }

        /// <summary>
        /// Lista de pessoas físicas cadastradas
        /// </summary>
        /// <returns>Objeto lista com as pessoas físicas cadastrados</returns>
        public IEnumerable<PessoaFisica> ListaTodos()
        {
            try
            {
				List<PessoaFisica> list = new List<PessoaFisica>();
                List<OracleParameter> lstParametros = new List<OracleParameter>();

                PessoaFisica pessoaFisica = null;

                BancoHelper objBanco = new BancoHelper();
				
				OracleDataReader reader;
			
                reader = objBanco.ProcedureExecute("PESSOA_FISICA_LISTA", lstParametros);
				
				while (reader.Read())
				{
					pessoaFisica = new PessoaFisica();
					pessoaFisica.ID = (int)reader["id"];
					pessoaFisica.CPF = reader["CPF"].ToString();
					pessoaFisica.Nome = reader["Nome"].ToString();
					pessoaFisica.Sobrenome = reader["Sobrenome"].ToString();

					if (reader["DataNasc"] != DBNull.Value)
						pessoaFisica.DataNasc = (DateTime)reader["DataNasc"];

					list.Add(pessoaFisica);
                }

                return list;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Erro - Pessoa Física: Lista - Mensagem:" + ex.Message + " - Execção: " + ex.InnerException);

                return null;
            }
            
        }

        /// <summary>
        /// Lista os produtos da pesquisa
        /// </summary>
        /// <param name="pesquisa">String com a pesquisa a ser feita, no nome da pessoa física</param>
        /// <returns>Lista de pessoas físicas com relação a pesquisa</returns>
        public IEnumerable<PessoaFisica> ListaPesquisa(string pesquisa)
        {
            try
            {
				List<PessoaFisica> list = new List<PessoaFisica>();
                List<OracleParameter> lstParametros = new List<OracleParameter>();

                PessoaFisica pessoaFisica = null;

                BancoHelper objBanco = new BancoHelper();

				OracleDataReader reader;
				
				lstParametros.Add(new OracleParameter("pesquisa", OracleDbType.Varchar2) { Value = pesquisa });
				
				reader = objBanco.ProcedureExecute("PESSOA_FISICA_PESQUISA", lstParametros);
			
                while (reader.Read())
                {

                    pessoaFisica = new PessoaFisica();
					pessoaFisica.ID = (int)reader["id"];
					pessoaFisica.CPF = reader["CPF"].ToString();
					pessoaFisica.Nome = reader["Nome"].ToString();
					pessoaFisica.Sobrenome = reader["Sobrenome"].ToString();

					if (reader["DataNasc"] != DBNull.Value)
						pessoaFisica.DataNasc = (DateTime)reader["DataNasc"];

                    list.Add(pessoaFisica);
                }

                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro - Pessoa Física: ListaPesquisa - Mensagem:" + ex.Message + " - Execção: " + ex.InnerException);

                return null;
            }
            
        }
    }
}