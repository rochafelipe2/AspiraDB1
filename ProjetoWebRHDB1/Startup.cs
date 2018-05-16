using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoWebRHDB1.Startup))]
namespace ProjetoWebRHDB1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
