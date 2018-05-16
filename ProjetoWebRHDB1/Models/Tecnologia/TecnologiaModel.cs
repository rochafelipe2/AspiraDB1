using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Models.Tecnologia
{
    public class TecnologiaModel
    {

        public TecnologiaModel()
        {
            this.Tecnologias = new List<TecnologiaViewModel>();
        }

        public TecnologiaDetail TecnologiaNova { get; set; }
        public TecnologiaDetail TecnologiaEdite { get; set; }

        public List<TecnologiaViewModel> Tecnologias { get; set; }

    }
}