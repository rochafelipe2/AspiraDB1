using ProjetoGitDB1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoWebDB1.Models
{
    public class UsuariosModel
    {
        public UsuariosModel()
        {
            this.Usuarios = new List<Usuario>();
        }

        public List<Usuario> Usuarios = new List<Usuario>();
    }
}