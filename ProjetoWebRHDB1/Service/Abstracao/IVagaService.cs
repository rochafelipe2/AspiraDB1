using ProjetoWebRHDB1.Models.Vaga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWebRHDB1.Service.Abstracao
{
    public interface IVagaService
    {

        bool Adicionar(VagaModel model);

        bool Atualizar(VagaModel model);

        List<VagaViewModel> ConsultarTodos();

        VagaDetail Consultar(long ID);

        bool Remover(long ID);

    }
}
