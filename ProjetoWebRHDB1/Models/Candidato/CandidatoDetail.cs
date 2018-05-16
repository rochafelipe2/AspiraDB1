using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Models.Candidato
{
    public class CandidatoDetail
    {

    
        public long ID { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        public string URL_Git { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Idade")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Tempo de experiência")]
        public int TempoExperiencia { get; set; }

        [Required(ErrorMessage = "campo obrigatório")]
        [Display(Name = "Formação")]
        public string Formacao { get; set; }

    }
}