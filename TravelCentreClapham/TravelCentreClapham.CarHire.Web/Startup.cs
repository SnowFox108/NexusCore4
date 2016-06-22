using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelCentreClapham.CarHire.Web.Startup))]
namespace TravelCentreClapham.CarHire.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
