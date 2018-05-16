using ProjetoWebRHDB1.Models.Entrevista;
using ProjetoWebRHDB1.Models.Tecnologia;
using ProjetoWebRHDB1.Service.Implementacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoWebRHDB1.Controllers
{
    public class EntrevistasController : Controller
    {

        private readonly CandidatoService CandidatoService;
        private readonly VagaService VagaService;
        private readonly EntrevistaService Service;
        private readonly TecnologiaService TecnologiaService;
        public EntrevistasController()
        {
            this.VagaService = new VagaService();
            this.CandidatoService = new CandidatoService();
            this.Service = new EntrevistaService();
            this.TecnologiaService = new TecnologiaService();
        }

        // GET: Entrevistas
        public ActionResult Index()
        {
            var model = new EntrevistaModel();

            model.Candidatos = CandidatoService.ConsultarTodos();
            model.Vagas = VagaService.ConsultarTodos();
            model.Entrevistas = Service.ConsultarTodos();
            model.Tecnologias = this.TecnologiaService.ConsultarTodos();

            return View(model);
        }

        public ActionResult IniciarEntrevista(EntrevistaModel model)
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

        [HttpGet]
        public ActionResult ContinuarEntrevista(Int64 ID)
        {
            var entrevista = this.Service.Consultar(ID);
            var vaga = this.VagaService.Consultar(entrevista.IDVaga);
            var candidato = this.CandidatoService.Consultar(entrevista.IDCandidato);
            var tecnologiasCandidato = this.Service.BuscarTecnologiasPorCandidato(candidato.ID);
            var tecnologias = new List<TecnologiaDetail>();
            foreach (var item in tecnologiasCandidato)
            {
                tecnologias.Add(this.TecnologiaService.Consultar(item.IDTecnologia));

            }

            var model = new ContinuarEntrevistaModel();

            model.IDCandidato = candidato.ID;
            model.Candidato = candidato.Nome;
            model.IDVaga = vaga.ID;
            model.Vaga = vaga.Nome;


            var tecnologiasEditadas = this.Service.ConsultarEntrevista(ID);

            foreach (var item in tecnologias)
            {
                var pesoEditado = tecnologiasEditadas.Where(x => x.IDEntrevista == ID && x.IDTecnologia == item.ID).FirstOrDefault();
                model.TecnologiasPeso.Add(new Models.Tecnologia.TecnologiaCandidato.TecnologiaCandidatoPesoDetail()
                {
                    IDTecnologia = item.ID,
                    IDEntrevista = ID,
                    Tecnologia = item.Nome,
                    Peso = pesoEditado != null && pesoEditado.Peso > 0 ? pesoEditado.Peso : 0,
                    ID = pesoEditado != null && pesoEditado.ID > 0 ? pesoEditado.ID : 0
                });
            }



            return View(model);
        }

        [HttpPost]
        public ActionResult ContinuarEntrevista(ContinuarEntrevistaModel model)
        {

            if (this.Service.SalvarEntrevista(model))
            {
                TempData["tagMessage"] = "sucesso";
                TempData["message"] = "Registro salvo com sucesso.";
            }
            else
            {
                TempData["tagMessage"] = "erro";
                TempData["message"] = "Erro ao salvar";
            }
            return RedirectToAction("ContinuarEntrevista", model.ID);
        }

        public ActionResult RankCandidato()
        {

            var model = new RankCandidatoModel();
            var candidatoTecnologias = this.Service.ConsultarEntrevista();
            model.RankCandidatos = this.Service.ConsultarRankCandidatos();

            return View(model);
        }
    }
}