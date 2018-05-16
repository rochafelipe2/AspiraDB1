using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Models.Vaga
{
    public class VagaModel
    {
        public VagaModel()
        {
            this.Vagas = new List<VagaViewModel>();
        }

        public VagaDetail VagaNova { get; set; }

        public VagaDetail VagaEdite { get; set; }

        public List<VagaViewModel> Vagas { get; set; }

    }
}