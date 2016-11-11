using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentCatalogFall2016.Startup))]
namespace StudentCatalogFall2016
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
