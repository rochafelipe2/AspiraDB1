using ProjetoWebRHDB1.Logic.Implementacao;
using ProjetoWebRHDB1.Models.Vaga;
using ProjetoWebRHDB1.Repository.Entity;
using ProjetoWebRHDB1.Service.Abstracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Service.Implementacao
{
    public class VagaService : IVagaService
    {

        private readonly VagaLogic Logic;

        public VagaService(){
            this.Logic = new VagaLogic();
        }

        public bool Adicionar(Models.Vaga.VagaModel model)
        {
            return this.Logic.Adicionar(ConverteDetailParaEnity(model.VagaNova));
        }

        public bool Atualizar(Models.Vaga.VagaModel model)
        {
            return this.Logic.Atualizar(ConverteDetailParaEnity(model.VagaEdite));
        }

        public List<Models.Vaga.VagaViewModel> ConsultarTodos()
        {
            return this.Logic.ConsultarTodos().Select(ConverteEnittyParaViewModel).ToList();
        }

        public Models.Vaga.VagaDetail Consultar(long ID)
        {
            return ConverteEntityPataDetail(this.Logic.Consultar(ID));
        }

        public bool Remover(long ID)
        {
            return this.Logic.Remover(ID);
        }

        private VagaEntity ConverteDetailParaEnity(VagaDetail d)
        {
            VagaEntity e = new VagaEntity();

            e.ID = d.ID;
            e.Descricao = d.Descricao;
            e.Nome = d.Nome;
            e.Responsavel = d.Responsavel;

            return e;
        }

        private VagaDetail ConverteEntityPataDetail(EntidadeBase e)
        {
            VagaDetail d = new VagaDetail();

            d.ID = e.ID;
            d.Descricao = e.Descricao;
            d.Nome = e.Nome;
            d.Responsavel = ((VagaEntity)e).Responsavel;

            return d;
        }

        private VagaViewModel ConverteEnittyParaViewModel(EntidadeBase e)
        {
            VagaViewModel vm = new VagaViewModel();

            vm.ID = e.ID;
            vm.Descricao = e.Descricao;
            vm.Nome = e.Nome;
            vm.Responsavel = ((VagaEntity)e).Responsavel;


            return vm;
        }
    }
}