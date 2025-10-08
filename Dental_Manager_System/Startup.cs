using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dental_Manager_System.Startup))]
namespace Dental_Manager_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
