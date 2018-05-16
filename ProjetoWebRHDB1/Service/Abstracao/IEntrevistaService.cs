using ProjetoWebRHDB1.Models.Entrevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWebRHDB1.Service.Abstracao
{
    public interface IEntrevistaService 
    {


        bool Adicionar(EntrevistaModel model);

        bool Atualizar(EntrevistaModel model);

        List<EntrevistaViewModel> ConsultarTodos();

        EntrevistaDetail Consultar(long ID);

        bool Remover(long ID);

    }
}
