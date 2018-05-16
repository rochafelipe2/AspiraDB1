using Newtonsoft.Json;
using Octokit;
using ProjetoGitDB1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace ProjetoWebDB1.Service
{
    public class GitService
    {
        public async Task<List<Usuario>> BuscarUsuarios()
        {
            string url = "https://api.github.com/users?since=135";
            List<Usuario> usuarios = new List<Usuario>();
            HttpWebRequest webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.UserAgent = "Anything";
                webRequest.ServicePoint.Expect100Continue = false;
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                try
                {
                    using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                    {
                        string reader = responseReader.ReadToEnd();
                        var jsonobj = JsonConvert.DeserializeObject(reader);

                        usuarios = JsonConvert.DeserializeObject<List<Usuario>>(jsonobj.ToString());

                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("Erro ao conectar com o servidor parceiro.");
                }
            }

            return usuarios;
        }

        public async Task<List<RepositorioModel>> BuscarRepositoriosPorUsuario(string login_usuario)
        {

            //List<RepositorioModel> repositorios = new List<RepositorioModel>();
            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //var github = new GitHubClient(new ProductHeaderValue("MyAmazingApp"));


            //var respositoryJson = await github.Repository.GetAllForUser(login_usuario);


            //repositorios = JsonConvert.DeserializeObject<List<RepositorioModel>>(respositoryJson.ToString());

             string url = "https://api.github.com/users/"+login_usuario+"/repos";
            List<RepositorioModel> repositorios = new List<RepositorioModel>();
            HttpWebRequest webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.UserAgent = "Anything";
                webRequest.ServicePoint.Expect100Continue = false;
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                try
                {
                    using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                    {
                        string reader = responseReader.ReadToEnd();
                        var jsonobj = JsonConvert.DeserializeObject(reader);

                        repositorios = JsonConvert.DeserializeObject<List<RepositorioModel>>(jsonobj.ToString());

                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("Erro ao conectar com o servidor parceiro.");
                }
            }

            return repositorios;
        }

        public async Task<Usuario> BuscarUsuario(string login)
        {

            string url = "https://api.github.com/users/" + login;
            Usuario usuario = new Usuario();
            HttpWebRequest webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.UserAgent = "Anything";
                webRequest.ServicePoint.Expect100Continue = false;
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                try
                {
                    using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                    {
                        string reader = responseReader.ReadToEnd();
                        var jsonobj = JsonConvert.DeserializeObject(reader);

                        usuario = JsonConvert.DeserializeObject<Usuario>(jsonobj.ToString());

                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("Erro ao conectar com o servidor parceiro.");
                }
            }

            return usuario;
        }
    }
}