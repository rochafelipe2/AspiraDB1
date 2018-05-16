using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Models.Vaga
{
    public class VagaDetail
    {

        public long ID {get;set;}

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Responsável")]
        public string Responsavel { get; set; }

    }
}