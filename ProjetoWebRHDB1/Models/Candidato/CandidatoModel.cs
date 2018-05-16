using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Models.Candidato
{
    public class CandidatoModel
    {

        public CandidatoModel()
        {
            this.Candidatos = new List<CandidatoViewModel>();
        }

        public CandidatoDetail CandidatoNovo { get; set; }

        public CandidatoDetail CandidatoEdite { get; set; }

        public List<CandidatoViewModel> Candidatos { get; set; }

    }
}