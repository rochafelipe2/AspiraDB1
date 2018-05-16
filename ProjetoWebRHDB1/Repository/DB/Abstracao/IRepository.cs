using ProjetoWebRHDB1.Repository.Criteria;
using ProjetoWebRHDB1.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWebRHDB1.Repository.DB.Abstracao
{
    public interface IRepository
    {

         bool Adicionar(EntidadeBase entidade);

         bool Adicionar(List<EntidadeBase> entidades);

         List<EntidadeBase> ConsultarTodos();

         EntidadeBase Consultar(CriteriaBase criteria);

         EntidadeBase Consultar(long ID);

         bool Atualizar(EntidadeBase entidade);

         bool Remover(long ID);

         bool Remover(List<long> IDs);

    }
}
