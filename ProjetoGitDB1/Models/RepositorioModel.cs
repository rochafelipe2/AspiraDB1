using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoGitDB1.Models
{
    public class RepositorioModel
    {
        public string id { get; set; }
        public string name {get;set;}
        public string full_name {get;set;}
        public string description {get;set;}
        public string url {get;set;}
        public string html_url {get;set;}
        public string created_at { get; set; }
        public string usuario { get; set; }
    }
}