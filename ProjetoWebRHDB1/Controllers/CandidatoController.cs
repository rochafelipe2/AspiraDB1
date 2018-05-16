using ProjetoWebRHDB1.Models.Candidato;
using ProjetoWebRHDB1.Service.Implementacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoWebRHDB1.Controllers
{
    public class CandidatoController : Controller
    {

        private readonly CandidatoService Service;

        public CandidatoController()
        {
            this.Service = new CandidatoService();
        }

        // GET: Candidato
        public ActionResult Index()
        {
            var model = new CandidatoModel();
            model.Candidatos = this.Service.ConsultarTodos();
            return View(model);
        }

        public ActionResult Adicionar(CandidatoModel model)
        {

            if (this.Service.Adicionar(model))
            {
                TempData["tagMessage"] = "sucesso";
                TempData["message"] = "Registro salvo com sucesso.";
            }
            else
            {
                TempData["tagMessage"] = "erro";
                TempData["message"] = "Erro ao salvar";
            }

            return RedirectToAction("Index");
        }

        public ActionResult Editar(CandidatoModel model)
        {

            if (this.Service.Atualizar(model))
            {
                TempData["tagMessage"] = "sucesso";
                TempData["message"] = "Registro salvo com sucesso.";
            }
            else
            {
                TempData["tagMessage"] = "erro";
                TempData["message"] = "Erro ao salvar";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Remover(long ID)
        {
            if(this.Service.Remover(ID))
            {
                TempData["tagMessage"] = "sucesso";
                TempData["message"] = "Registro salvo com sucesso.";
            }
            else
            {
                TempData["tagMessage"] = "erro";
                TempData["message"] = "Registro salvo com sucesso.";
            }
            return RedirectToAction("Index");
                
        }
        public JsonResult ActionCarregarCandidatoParaEdicao(string id)
        {
            var resultado = new JsonResult();


            var candidatoDetail = this.Service.Consultar(long.Parse(id));

            resultado.Data = candidatoDetail;
            resultado.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return resultado;
        }
    }
}