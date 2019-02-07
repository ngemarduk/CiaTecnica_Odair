using CiaTecnica_MVC.Models;
using CiaTecnica_MVC.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace CiaTecnica_MVC.Controllers
{
    /// <summary>
    /// API referente ao cliente
    /// </summary>
    [RoutePrefix("api/Cliente")]
    public class ClienteController : ApiController
    {
        /// <summary>
        /// Lista de clientes cadastrados
        /// </summary>
        /// <returns>JSON com os clientes cadastrados</returns>
        [HttpGet]
        [Route("Lista")]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Lista()
        {
            try
            {
                ClienteRepository clienteRepository = new ClienteRepository();

                List<PessoaFisicaJuridica> lstPessoaFisicaJuridicas = new List<PessoaFisicaJuridica>();

                lstPessoaFisicaJuridicas = clienteRepository.ListaTodos();

                return await Task.FromResult(Json(lstPessoaFisicaJuridicas));
            }
            catch (System.ArgumentException ae)
            {
                return await Task.FromResult(BadRequest(ae.Message.ToString()));

            }

        }
    }
}
