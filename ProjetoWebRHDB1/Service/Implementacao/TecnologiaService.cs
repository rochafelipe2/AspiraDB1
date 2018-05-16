using ProjetoWebRHDB1.Logic.Implementacao;
using ProjetoWebRHDB1.Models.Tecnologia;
using ProjetoWebRHDB1.Repository.Entity;
using ProjetoWebRHDB1.Service.Abstracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Service.Implementacao
{
    public class TecnologiaService : ITecnologiaService
    {
        private readonly TecnologiaLogic Logic;

        public TecnologiaService()
        {
            this.Logic = new TecnologiaLogic();
        }

        public bool Adicionar(Models.Tecnologia.TecnologiaModel model)
        {
            return this.Logic.Adicionar(ConverteDetailParaEntity(model.TecnologiaNova));
        }

        public bool Atualizar(Models.Tecnologia.TecnologiaModel model)
        {
            return this.Logic.Atualizar(ConverteDetailParaEntity(model.TecnologiaEdite));
        }

        public List<Models.Tecnologia.TecnologiaViewModel> ConsultarTodos()
        {
            return this.Logic.ConsultarTodos().Select(ConverteEntityParaVM).ToList();
        }

        public Models.Tecnologia.TecnologiaDetail Consultar(long ID)
        {
            return ConverteEntityParaDetail(this.Logic.Consultar(ID));
        }

        public bool Remover(long ID)
        {
            return this.Logic.Remover(ID);
        }

        private TecnologiaDetail ConverteEntityParaDetail(EntidadeBase e)
        {
            TecnologiaDetail d = new TecnologiaDetail();

            d.ID = e.ID;
            d.Nome = e.Nome;

            return d;
        }

        private TecnologiaViewModel ConverteEntityParaVM(EntidadeBase e)
        {
            TecnologiaViewModel vm = new TecnologiaViewModel();

            vm.ID = e.ID;
            vm.Nome = e.Nome;

            return vm;
        }

        private TecnologiaEntity ConverteDetailParaEntity(TecnologiaDetail d)
        {
            TecnologiaEntity e = new TecnologiaEntity();

            e.ID = d.ID;
            e.Nome = d.Nome;
            return e; 
        }
    }
}