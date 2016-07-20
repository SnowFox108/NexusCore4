using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TravelCentreClapham.FlyAfricaDirect.WebApi.Startup))]

namespace TravelCentreClapham.FlyAfricaDirect.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
