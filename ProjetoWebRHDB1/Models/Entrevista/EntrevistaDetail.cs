using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Models.Entrevista
{
    public class EntrevistaDetail
    {
        public long ID { get; set; }

        public long IDVaga { get; set; }

        public long IDCandidato { get; set; }
    }
}