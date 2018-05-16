using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebDB1.Models
{
    public class UsuarioDetail
    {

        public UsuarioDetail()
        {
            this.repositorios = new List<RepositorioDetail>();
        }

        public string id { get; set; }

        public string login { get; set; }

        public string url { get; set; }

        public string dataCriacao { get; set; }

        public List<RepositorioDetail> repositorios { get; set; }
    }
}