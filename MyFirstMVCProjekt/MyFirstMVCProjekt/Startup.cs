using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyFirstMVCProjekt.Startup))]
namespace MyFirstMVCProjekt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
