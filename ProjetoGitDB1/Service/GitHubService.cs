using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Runtime.Serialization.Json;
using ProjetoGitDB1.Models;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Octokit;
using System.Net;
using System.Text;


namespace ProjetoGitDB1.Service
{
    public class GitHubService
    {

        private static readonly HttpClient client = new HttpClient();



        public List<Usuario> BuscarUsuarios()
        {
            string url = "https://api.github.com/users?since=135";
            List<Usuario> usuarios = new List<Usuario>();
            HttpWebRequest webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.UserAgent = "Anything";
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.ClientCertificates = new System.Security.Cryptography.X509Certificates.X509CertificateCollection();
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

        public async Task<Usuario> BuscarUsuario(string login)
        {
            Usuario usuario = new Usuario();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var github = new GitHubClient(new ProductHeaderValue("MyAmazingApp"));

            var usuarioJson = await github.User.Get(login);

             usuario = JsonConvert.DeserializeObject<Usuario>(usuarioJson.ToString());

             return usuario;
        }


    }
}