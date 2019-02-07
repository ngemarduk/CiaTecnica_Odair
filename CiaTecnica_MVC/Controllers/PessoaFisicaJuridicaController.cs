using System.Web.Mvc;

namespace CiaTecnica_MVC.Controllers
{
    public class PessoaFisicaJuridicaController : Controller
    {
		/*
		https://stackoverflow.com/questions/9997874/multiple-forms-in-same-page-asp-net-mvc/9998040
		https://viacep.com.br/
		
		-AdminLTE
		- tutorial para implementar o template -> https://www.howtosolutions.net/2017/05/visual-studio-asp-net-mvc-project-installing-adminlte-control-panel/ 
		- link pra baixar o template https://github.com/almasaeed2010/AdminLTE/releases/tag/v2.4.0 
		- Jquery Confirm
			http://craftpip.github.io/jquery-confirm/ 
		*/
       
        // GET: PessoaFisicaJuridica/Create
        public ActionResult Create()
        {
            return View();
        }

        
    }
}
