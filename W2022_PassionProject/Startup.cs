using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(W2022_PassionProject.Startup))]
namespace W2022_PassionProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
