using ProjetoWebRHDB1.Models.Candidato;
using ProjetoWebRHDB1.Models.Tecnologia;
using ProjetoWebRHDB1.Models.Vaga;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Models.Entrevista
{
    public class EntrevistaModel
    {

        public EntrevistaModel()
        {
            Vagas = new List<VagaViewModel>();
            Candidatos = new List<CandidatoViewModel>();
            Tecnologias = new List<TecnologiaViewModel>();
            TecnologiasCandidato = new List<TecnologiaViewModel>();
            Entrevistas = new List<EntrevistaViewModel>();
            this.TecnologiasSelecionadas = new List<long>();
        }


        [Display(Name = "Vaga")]
        public List<VagaViewModel> Vagas { get; set; }
        public long VagaSelecionado { get; set; }

     
        [Display(Name = "Candidato")]
        public List<CandidatoViewModel> Candidatos {get;set;}
        public long CandidatoSelecionado { get; set; }

       
        [Display(Name = "Tecnologias")]
        public List<TecnologiaViewModel> Tecnologias { get; set; }

        public List<long> TecnologiasSelecionadas { get; set; }

        [Display(Name = "Tecnologias do candidato")]
        public List<TecnologiaViewModel> TecnologiasCandidato { get; set; }

        public List<EntrevistaViewModel> Entrevistas { get; set; }

        public string IDsTecnologiasCandidado { get; set; }

    }
}