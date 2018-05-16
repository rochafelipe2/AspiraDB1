using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Models.Entrevista
{
    public class RankCandidatoModel
    {
        public RankCandidatoModel()
        {
            this.RankCandidatos = new List<CandidatoRankViewModel>();
        }

        public List<CandidatoRankViewModel> RankCandidatos { get; set; }

    }
}