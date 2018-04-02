using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PsychologyProject.Startup))]
namespace PsychologyProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
