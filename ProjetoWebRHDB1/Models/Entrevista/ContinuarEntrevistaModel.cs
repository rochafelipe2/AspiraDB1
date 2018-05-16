using ProjetoWebRHDB1.Models.Tecnologia.TecnologiaCandidato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Models.Entrevista
{
    public class ContinuarEntrevistaModel
    {
        public ContinuarEntrevistaModel()
        {
            this.TecnologiasPeso = new List<TecnologiaCandidatoPesoDetail>();
        }


        public long ID { get; set; }

        public long IDCandidato { get; set; }

        public long IDVaga { get; set; }

        public string Candidato { get; set; }

        public string Vaga { get; set; }


        public List<TecnologiaCandidatoPesoDetail> TecnologiasPeso { get; set; }

    }
}