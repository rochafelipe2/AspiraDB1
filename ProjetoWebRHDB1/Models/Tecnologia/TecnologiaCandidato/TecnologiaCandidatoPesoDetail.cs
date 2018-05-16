using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Models.Tecnologia.TecnologiaCandidato
{
    public class TecnologiaCandidatoPesoDetail
    {

        public long ID { get; set; }

        public long IDEntrevista { get; set; }

        public long IDTecnologia { get; set; }
        public string Tecnologia { get; set; }

        [Display(Name = "Peso")]
        public int Peso { get; set; }

    }
}