using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeeSolution.Startup))]
namespace BeeSolution
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
