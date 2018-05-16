using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoWebRHDB1.Models.Tecnologia
{
    public class TecnologiaDetail
    {
        public long ID { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

    }
}