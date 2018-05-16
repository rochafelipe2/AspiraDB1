using ProjetoGitDB1.Service;
using ProjetoWebDB1.Models;
using ProjetoWebDB1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoWebDB1.Controllers
{
    public class GithubController : Controller
    {
        // GET: Github
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Usuarios()
        {
            var model = new UsuariosModel();
            var gitService = new GitService();
            model.Usuarios = gitService.BuscarUsuarios().Result;

            return View(model); 
        }
        
        public ActionResult UsuarioDetalhe(string login)
        {
            var usuarioDetail = new UsuarioDetail();
            var gitService = new GitService();
            var repositorioService = new RepositorioService();
            var usuario = gitService.BuscarUsuario(login);

            usuarioDetail.id = usuario.Result.id;
            usuarioDetail.login = usuario.Result.login;
            usuarioDetail.dataCriacao = usuario.Result.created_at;
            usuarioDetail.repositorios = gitService.BuscarRepositoriosPorUsuario(login).Result.Select(repositorioService.ConverterEntityParaDetail).ToList();

            return View(usuarioDetail); 
        }
    }
}