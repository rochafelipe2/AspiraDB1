﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetoWebDB1.Startup))]
namespace ProjetoWebDB1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
