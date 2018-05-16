using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Repository.Entity
{
    public class EntrevistaTecnologiaPesoEntity : EntidadeBase
    {


        public long IDEntrevista { get; set; }

        public long IDTecnologia { get; set; }

        public int Peso { get; set; }

    }
}