using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScienceJourney.Startup))]
namespace ScienceJourney
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
