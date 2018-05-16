using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Models.Entrevista
{
    public class EntrevistaViewModel
    {
        public long ID { get; set; }
        public string Candidato { get; set; }
        public long IDCandidato { get; set; }

        public string Vaga { get; set; }
        public long IDVaga { get; set; }

    }
}