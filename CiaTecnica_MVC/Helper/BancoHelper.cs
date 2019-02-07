using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace CiaTecnica_MVC.Helper
{
    public class BancoHelper
    {
        private String strConexao = WebConfigurationManager.ConnectionStrings["conexao"].ConnectionString;

        public OracleConnection conn = null;

        public BancoHelper()
        {
            AbrirConexao();
        }

        /// <summary>
        /// Abre a conexão com o banco de dados
        /// </summary>
        public void AbrirConexao()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn = new OracleConnection(strConexao);
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erro - Banco: AbrirConexao - Mensagem:" + ex.Message + " - Execção: " + ex.InnerException);
            }
        }
		
        /// <summary>
        /// Excecução genérica de procedure
        /// </summary>
        /// <param name="procedureName">Nome da procedure</param>
        /// <param name="parameters">Paramêtros da procedure</param>
        /// <returns>Data reader</returns>
		public OracleDataReader ProcedureExecute(string procedureName, List<OracleParameter> parameters)
		{
			OracleDataReader dr;
			
			try
			{
				AbrirConexao();
				
				using (OracleCommand sqlCommand = new OracleCommand(procedureName, conn))
				{
                    sqlCommand.CommandType = CommandType.StoredProcedure;
					
					if (parameters != null)
					{
                        sqlCommand.Parameters.AddRange(parameters.ToArray());
					}
					
					dr = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

                    return dr;
                }
			
			}catch(Exception ex){
				Debug.WriteLine("Erro Banco:" + ex);

                return null;
			}
			
		}
    }
}