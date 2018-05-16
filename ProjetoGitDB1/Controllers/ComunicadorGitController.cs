using ProjetoGitDB1.Models;
using ProjetoGitDB1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetoGitDB1.Controllers
{
    [Authorize]
    public class ComunicadorGitController : ApiController
    {

        // POST api/Account/RemoveLogin
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Usuario> BuscarUsuarios(int paginacao)
        {
            var gitService = new GitHubService();

            gitService.BuscarUsuario("rochafelipe");
            return null;
        }

    }
}
