using ProjetoWebRHDB1.Models.Tecnologia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoWebRHDB1.Service.Abstracao
{
    public interface ITecnologiaService
    {

        bool Adicionar(TecnologiaModel model);

        bool Atualizar(TecnologiaModel model);

        List<TecnologiaViewModel> ConsultarTodos();

        TecnologiaDetail Consultar(long ID);

        bool Remover(long ID);
    }
}
