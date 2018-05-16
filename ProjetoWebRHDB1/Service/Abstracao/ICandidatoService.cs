using ProjetoWebRHDB1.Models.Candidato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWebRHDB1.Service.Abstracao
{
    public interface ICandidatoService
    {

         bool Adicionar(CandidatoModel model);

         bool Atualizar(CandidatoModel model);

         List<CandidatoViewModel> ConsultarTodos();

         CandidatoDetail Consultar(long ID);

         bool Remover(long ID);
    }
}
