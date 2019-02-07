using CiaTecnica_MVC.Models;
using CiaTecnica_MVC.Repository;
using System;
using System.Web.Mvc;

namespace CiaTecnica_MVC.Controllers
{
    public class PessoaFisicaController : Controller
    {
        // GET: PessoaFisica
        public ActionResult Index()
        {
            return View();
        }

        // GET: PessoaFisica/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PessoaFisica/Create
        [HttpPost]
        public ActionResult Create(PessoaFisica pessoaFisica)
        {
            try
            {
				if (ModelState.IsValid)
				{
					PessoaFisicaRepository pfRep = new PessoaFisicaRepository();
					
					if (pfRep.Inserir(pessoaFisica) == 0)
					{
						ModelState.AddModelError("", "Não foi possível cadastrar a pessoa física.");
						return View(pessoaFisica);
					}else{
						return RedirectToAction("Index");
					}
					
				}else{
					ModelState.AddModelError("", "Os dados do formulário estão incorretos.");
					return View(pessoaFisica);
				}
                
            }
            catch(Exception ex )
            {
				ModelState.AddModelError("", "Os dados do formulário estão incorretos: "+ ex);
                return View(pessoaFisica);
            }
        }

        // GET: PessoaFisica/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
				PessoaFisicaRepository pfRep = new PessoaFisicaRepository();

                PessoaFisica pessoaFisica = new PessoaFisica();
			
				pessoaFisica = pfRep.Dados(id);
				
				if ( pessoaFisica != null)
				{
					return View(pessoaFisica);
				}else{
					TempData["Mensagem"]="Não foi possivel localizar a Pessoa física.";
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex )
            {
                TempData["Mensagem"] = "Não foi possível carregar os dados da pessoa física: " + ex;
                return RedirectToAction("Index");
            }
        }

        // POST: PessoaFisica/Edit/5
        [HttpPost]
        public ActionResult Edit(PessoaFisica pessoaFisica)
        {
            try
            {
				if (ModelState.IsValid)
				{
					PessoaFisicaRepository pfRep = new PessoaFisicaRepository();
					
					if (pfRep.Alterar(pessoaFisica) == 0)
					{
						ModelState.AddModelError("", "Não foi possível alterar a pessoa física.");
						return View(pessoaFisica);
					}else{
						TempData["Mensagem"]="Pessoa física alterada com sucesso.";
						return RedirectToAction("Index");
					}
					
				}else{
					ModelState.AddModelError("", "Os dados do formulário estão incorretos.");
					return View(pessoaFisica);
				}
                
            }
            catch(Exception ex )
            {
				ModelState.AddModelError("", "Os dados do formulário estão incorretos.");
                return View(pessoaFisica);
            }
        }
        
        // POST: PessoaFisica/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                PessoaFisicaRepository pfRep = new PessoaFisicaRepository();
				
				if ( pfRep.Apagar(id) > 0)
				{
					TempData["Error"]="Ocorreu um erro ao apagar a pessoa física";
				}else{
					TempData["Mensagem"]="Pessoa física apagada com sucesso.";
				}
				
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
