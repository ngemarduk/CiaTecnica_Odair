using CiaTecnica_MVC.Models;
using CiaTecnica_MVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CiaTecnica_MVC.Controllers
{
    public class PessoaJuridicaController : Controller
    {
        // GET: PessoaJuridica
        public ActionResult Index()
        {
            return View();
        }

        // GET: PessoaFisica/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PessoaJuridica/Create
        [HttpPost]
        public ActionResult Create(PessoaJuridica pessoaJuridica)
        {
            try
            {
				if (ModelState.IsValid)
				{
					PessoaJuridicaRepository pjRep = new PessoaJuridicaRepository();
					
					if (pjRep.Inserir(pessoaJuridica) == 0)
					{
						ModelState.AddModelError("", "Não foi possível cadastrar a pessoa jurídica.");
						return View(pessoaJuridica);
					}else{
						return RedirectToAction("Index");
					}
					
				}else{
					ModelState.AddModelError("", "Os dados do formulário estão incorretos.");
					return View(pessoaJuridica);
				}
                
            }
            catch(Exception ex )
            {
				ModelState.AddModelError("", "Os dados do formulário estão incorretos. "+ ex);
                return View(pessoaJuridica);
            }
        }

        // GET: PessoaJuridica/Edit/5
        public ActionResult Edit(int id)
        {
            try
            { 
                PessoaJuridicaRepository pfRep = new PessoaJuridicaRepository();

                PessoaJuridica objPessoaJuridica = new PessoaJuridica();
			
				objPessoaJuridica = pfRep.Dados(id);
				
				if (objPessoaJuridica != null)
				{
					return View(objPessoaJuridica);
				}else{
					TempData["Mensagem"]="Não foi possivel localizar a Pessoa física.";
					return RedirectToAction("Index");
				}
					
            }
            catch(Exception ex)
            {
                TempData["Mensagem"] = "Não foi possível carregar os dados da pessoa jurídica: " + ex;
                return RedirectToAction("Index");
            }
        }

        // POST: PessoaJuridica/Edit/5
        [HttpPost]
        public ActionResult Edit(PessoaJuridica pessoaJuridica)
        {
            try
            {
				if (ModelState.IsValid)
				{
					PessoaJuridicaRepository  pjRep = new PessoaJuridicaRepository ();
					
					if (pjRep.Alterar(pessoaJuridica) == 0)
					{
						ModelState.AddModelError("", "Não foi possível alterar a pessoa física.");
						return View(pessoaJuridica);
					}else{
						TempData["Mensagem"]="Pessoa física alterada com sucesso.";
						return RedirectToAction("Index");
					}
					
				}else{
					ModelState.AddModelError("", "Os dados do formulário estão incorretos.");
					return View(pessoaJuridica);
				}
                
            }
            catch(Exception ex )
            {
				ModelState.AddModelError("", "Os dados do formulário estão incorretos. " + ex);
                return View(pessoaJuridica);
            }
        }
        
        // POST: PessoaJuridica/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                PessoaJuridicaRepository pjRep = new PessoaJuridicaRepository();
			
				if ( pjRep.Apagar(id) > 0)
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
