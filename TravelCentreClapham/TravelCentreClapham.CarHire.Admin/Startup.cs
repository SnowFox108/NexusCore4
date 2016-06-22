using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelCentreClapham.CarHire.Admin.Startup))]
namespace TravelCentreClapham.CarHire.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
