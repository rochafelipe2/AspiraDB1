using ProjetoGitDB1.Models;
using ProjetoWebDB1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebDB1.Service
{
    public class RepositorioService
    {

        public RepositorioDetail ConverterEntityParaDetail(RepositorioModel model)
        {
            RepositorioDetail detail = new RepositorioDetail();

            detail.id = model.id;
            detail.nome = model.name;
            detail.url = model.url;
            detail.usuario = model.usuario;

            return detail;
        }

    }
}