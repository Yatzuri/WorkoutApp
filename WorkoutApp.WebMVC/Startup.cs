using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorkoutApp.WebMVC.Startup))]
namespace WorkoutApp.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
