using ProjetoWebRHDB1.Logic.Abstracao;
using ProjetoWebRHDB1.Logic.Implementacao;
using ProjetoWebRHDB1.Models.Entrevista;
using ProjetoWebRHDB1.Models.Tecnologia.TecnologiaCandidato;
using ProjetoWebRHDB1.Repository.Entity;
using ProjetoWebRHDB1.Service.Abstracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Service.Implementacao
{
    public class EntrevistaService : IEntrevistaService
    {
        private readonly EntrevistaLogic Logic;
        private readonly CandidatoLogic CandidatoLogic;
        private readonly VagaLogic VagaLogic;

        public EntrevistaService()
        {
            this.Logic = new EntrevistaLogic();
            this.CandidatoLogic = new CandidatoLogic();
            this.VagaLogic = new VagaLogic();
        }

        public bool Adicionar(Models.Entrevista.EntrevistaModel model)
        {
            var entidade = new CandidatoVagaEntitycs();
            entidade.IDCandidato = model.CandidatoSelecionado;
            entidade.IDVaga = model.VagaSelecionado;

            var split = model.IDsTecnologiasCandidado.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var id in split)
            {
                model.TecnologiasSelecionadas.Add(long.Parse(id));
            }

            foreach (var item in model.TecnologiasSelecionadas)
            {
                var novoCandidatoTecnologia = new TecnologiaCandidatoEntity()
                {
                    IDCandidato = model.CandidatoSelecionado,
                    IDTecnologia = item
                };

                this.Logic.AdicionarCandidatoTec(novoCandidatoTecnologia);
            }


            return Logic.Adicionar(entidade);
        }

        public bool Atualizar(Models.Entrevista.EntrevistaModel model)
        {
            throw new NotImplementedException();
        }

        public List<Models.Entrevista.EntrevistaViewModel> ConsultarTodos()
        {
            return this.Logic.ConsultarTodos().Select(ConverteEntityParaVM).ToList();
        }

        public Models.Entrevista.EntrevistaDetail Consultar(long ID)
        {
            return ConverteEntityParaDetail(this.Logic.Consultar(ID));
        }

        public bool Remover(long ID)
        {
            throw new NotImplementedException();
        }

        public bool SalvarEntrevista(ContinuarEntrevistaModel model)
        {
            bool verificador = false;
            foreach(var item in model.TecnologiasPeso)
            {
       

                var entity = new EntrevistaTecnologiaPesoEntity();

                entity.IDEntrevista = item.IDEntrevista;
                entity.IDTecnologia = item.IDTecnologia;
                entity.Peso = item.Peso;
                entity.ID = item.ID;
                verificador = this.Logic.SalvarEntrevista(entity);
            }

            return verificador;
        
        }

        public List<TecnologiaCandidatoPesoDetail> ConsultarEntrevista(long ID)
        {
            return this.Logic.ConsultarEntrevista(ID).Select(ConverteEntityParaDetailTecnologiaCandidatoPesoDetail).ToList();
        }

        public List<TecnologiaCandidatoPesoDetail> ConsultarEntrevista()
        {
            return this.Logic.ConsultarEntrevista().Select(ConverteEntityParaDetailTecnologiaCandidatoPesoDetail).ToList();
        }

        public List<CandidatoRankViewModel> ConsultarRankCandidatos()
        {
            return this.Logic.ConsultarRankCandidatos();
        }

        public EntrevistaViewModel ConverteEntityParaVM(EntidadeBase e)
        {
            EntrevistaViewModel vm = new EntrevistaViewModel();

            vm.IDCandidato = ((CandidatoVagaEntitycs)e).IDCandidato;
            vm.IDVaga = ((CandidatoVagaEntitycs)e).IDVaga;
            vm.ID = e.ID;
            vm.Candidato = this.CandidatoLogic.Consultar(vm.IDCandidato).Nome;
            vm.Vaga = this.VagaLogic.Consultar(vm.IDVaga).Nome;
            return vm;
        }

        public List<TecnologiaCandidatoViewMode> BuscarTecnologiasPorCandidato(long ID)
        {
            return this.Logic.ConsultarPorCandidato(ID).Select(ConverteEntityParaVM).ToList();
        }

        private TecnologiaCandidatoViewMode ConverteEntityParaVM(TecnologiaCandidatoEntity e)
        {
            TecnologiaCandidatoViewMode vm = new TecnologiaCandidatoViewMode();

            vm.IDCandidato = e.IDCandidato;
            vm.IDTecnologia = e.IDTecnologia;

            return vm;
        }

        public EntrevistaDetail ConverteEntityParaDetail (EntidadeBase e)
        {
            EntrevistaDetail d = new EntrevistaDetail();

            d.ID = e.ID;
            d.IDCandidato = ((CandidatoVagaEntitycs)e).IDCandidato;
            d.IDVaga = ((CandidatoVagaEntitycs)e).IDVaga;

            return d;
        }

        public TecnologiaCandidatoPesoDetail ConverteEntityParaDetailTecnologiaCandidatoPesoDetail(EntidadeBase e)
        {
            TecnologiaCandidatoPesoDetail d = new TecnologiaCandidatoPesoDetail();
            d.ID = e.ID;
            d.IDEntrevista = ((EntrevistaTecnologiaPesoEntity)e).IDEntrevista;
            d.IDTecnologia = ((EntrevistaTecnologiaPesoEntity)e).IDTecnologia;
            d.Peso = ((EntrevistaTecnologiaPesoEntity)e).Peso;

            return d;
        }
    }
}