using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RealtorCMS.Startup))]
namespace RealtorCMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
