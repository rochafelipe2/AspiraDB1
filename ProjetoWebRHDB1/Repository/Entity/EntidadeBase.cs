using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Repository.Entity
{
    public class EntidadeBase
    {
        public long ID { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

    }
}