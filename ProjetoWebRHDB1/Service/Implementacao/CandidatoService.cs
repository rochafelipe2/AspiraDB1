using ProjetoWebRHDB1.Logic.Abstracao;
using ProjetoWebRHDB1.Logic.Implementacao;
using ProjetoWebRHDB1.Models.Candidato;
using ProjetoWebRHDB1.Repository.Entity;
using ProjetoWebRHDB1.Service.Abstracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Service.Implementacao
{
    public class CandidatoService : ICandidatoService
    {
        private readonly ICandidatoLogic Logic;

        public CandidatoService()
        {
            this.Logic = new CandidatoLogic();
        }

        public bool Adicionar(Models.Candidato.CandidatoModel model)
        {
            return this.Logic.Adicionar(ConverteDetailParaEntity(model.CandidatoNovo));
        }

        public bool Atualizar(Models.Candidato.CandidatoModel model)
        {

            var updated = this.Consultar(model.CandidatoEdite.ID);

            updated.Nome = model.CandidatoEdite.Nome;
            updated.Idade = model.CandidatoEdite.Idade;
            updated.Formacao = model.CandidatoEdite.Formacao;
            updated.TempoExperiencia = model.CandidatoEdite.TempoExperiencia;


            return this.Logic.Atualizar(ConverteDetailParaEntity(updated));
        }

        public List<Models.Candidato.CandidatoViewModel> ConsultarTodos()
        {
            return this.Logic.ConsultarTodos().Select(ConverteEntityParaVM).ToList();
        }

        public Models.Candidato.CandidatoDetail Consultar(long ID)
        {
            return ConverteEntityParaDetail(this.Logic.Consultar(ID));
        }

        private CandidatoViewModel ConverteEntityParaVM(EntidadeBase entity)
        {
            CandidatoViewModel vm = new CandidatoViewModel();

            vm.ID = entity.ID;
            vm.Nome = entity.Nome;
 
            return vm;
        }

        private CandidatoEntity ConverteDetailParaEntity(CandidatoDetail detail)
        {
            CandidatoEntity e = new CandidatoEntity();

            e.ID = detail.ID;
            e.Nome = detail.Nome;
            e.Idade = detail.Idade;
            e.TempoExperiencia = detail.TempoExperiencia;
            e.URL_Git = detail.URL_Git;
            e.Formacao = detail.Formacao;
            return e;
        }

        private CandidatoDetail ConverteEntityParaDetail(EntidadeBase entity)
        {
            CandidatoDetail detail = new CandidatoDetail();
            var e = (CandidatoEntity)entity;
            detail.ID = e.ID;
            detail.Nome = e.Nome;
            detail.Formacao = e.Formacao;
            detail.Idade = e.Idade;
            detail.TempoExperiencia = e.TempoExperiencia;
            detail.URL_Git = e.URL_Git;

            return detail;
        }


        public bool Remover(long ID)
        {
            return this.Logic.Remover(ID);
        }
    }
}