using ProjetoWebRHDB1.Models.Tecnologia;
using ProjetoWebRHDB1.Service.Implementacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoWebRHDB1.Controllers
{
    public class TecnologiasController : Controller
    {
        private readonly TecnologiaService Service;

        public TecnologiasController()
        {
            this.Service = new TecnologiaService();
        }

        // GET: Tecnologias
        public ActionResult Index()
        {
            var model = new TecnologiaModel();

            model.Tecnologias = Service.ConsultarTodos();

            return View(model);
        }

        public ActionResult Adicionar(TecnologiaModel model)
        {
            if (this.Service.Adicionar(model))
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

        public ActionResult Atualizar(TecnologiaModel model)
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

        public JsonResult ActionConsultarTecnologiaParaEdicao(string id)
        {
            var resultado = new JsonResult();
            resultado.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            resultado.Data = Service.Consultar(long.Parse(id));

            return resultado;
        }
    }
}