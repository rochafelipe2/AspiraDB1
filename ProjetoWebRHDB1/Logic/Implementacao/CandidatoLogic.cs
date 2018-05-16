using ProjetoWebRHDB1.Logic.Abstracao;
using ProjetoWebRHDB1.Repository.DB.Implementacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Logic.Implementacao
{
    public class CandidatoLogic : ICandidatoLogic
    {
        private readonly CandidatoRepository Repository;

        public CandidatoLogic()
        {
            this.Repository = new CandidatoRepository();
        }

        public bool Adicionar(Repository.Entity.EntidadeBase entidade)
        {
           return this.Repository.Adicionar(entidade);
        }

        public bool Adicionar(List<Repository.Entity.EntidadeBase> entidades)
        {
            return this.Repository.Adicionar(entidades);
        }

        public List<Repository.Entity.EntidadeBase> ConsultarTodos()
        {
            return this.Repository.ConsultarTodos();
        }

        public Repository.Entity.EntidadeBase Consultar(Repository.Criteria.CriteriaBase criteria)
        {
          return this.Repository.Consultar(criteria);
        }

        public Repository.Entity.EntidadeBase Consultar(long ID)
        {
            return this.Repository.Consultar(ID);
        }

        public bool Atualizar(Repository.Entity.EntidadeBase entidade)
        {
            return this.Repository.Atualizar(entidade);
        }

        public bool Remover(long ID)
        {
            return this.Repository.Remover(ID);
        }

        public bool Remover(List<long> IDs)
        {
            return this.Repository.Remover(IDs);
        }
    }
}