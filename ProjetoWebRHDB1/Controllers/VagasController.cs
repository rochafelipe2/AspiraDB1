using ProjetoWebRHDB1.Models.Vaga;
using ProjetoWebRHDB1.Service.Implementacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoWebRHDB1.Controllers
{
    public class VagasController : Controller
    {

        private readonly VagaService Service;

        public VagasController()
        {
            this.Service = new VagaService();
        }

        // GET: Vagas
        public ActionResult Index()
        {
            var model = new VagaModel();

            model.Vagas = this.Service.ConsultarTodos();

            return View(model);
        }

        public ActionResult Adicionar(VagaModel model)
        {

            if(this.Service.Adicionar(model))
            {
                TempData["tagMessage"] = "sucesso";
                TempData["message"] = "Registro salvo com sucesso.";
            }
            else
            {
                TempData["tagMessage"] = "erro";
                TempData["message"] = "Erro ao salvar registro.";
            }

            return RedirectToAction("Index");
        }

        public ActionResult Atualizar(VagaModel model)
        {

            if (this.Service.Atualizar(model))
            {
                TempData["tagMessage"] = "sucesso";
                TempData["message"] = "Registro salvo com sucesso.";
            }
            else
            {
                TempData["tagMessage"] = "erro";
                TempData["message"] = "Erro ao salvar registro.";
            }

            return RedirectToAction("Index");
        }

        public ActionResult Remover(long ID)
        {

            if (this.Service.Remover(ID))
            {
                TempData["tagMessage"] = "sucesso";
                TempData["message"] = "Registro salvo com sucesso.";
            }
            else
            {
                TempData["tagMessage"] = "erro";
                TempData["message"] = "Erro ao salvar registro.";
            }

            return RedirectToAction("Index");
        }

        public JsonResult ActionCarregarVagaParaEdicao(string id)
        {
            var resultado = new JsonResult();
            resultado.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            resultado.Data = this.Service.Consultar(long.Parse(id));

            return resultado;
        }
    }
}