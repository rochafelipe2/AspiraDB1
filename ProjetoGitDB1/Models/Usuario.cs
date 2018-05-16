using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoGitDB1.Models
{
    public class Usuario
    {
        public Usuario()
        {

        }

        public string login { get; set; }
        public string id { get; set; }
        public string avatar_url { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string created_at { get; set; }

    }
}