using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Repository.Entity
{
    public class CandidatoEntity : EntidadeBase
    {

        public int Idade { get; set; }
        public int TempoExperiencia { get; set; }
        public string URL_Git { get; set; }
        public string Formacao { get; set; }

    }
}