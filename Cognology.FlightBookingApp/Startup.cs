using Microsoft.Owin;
using Owin;
using Swashbuckle;
using System.Web.Http;

[assembly: OwinStartupAttribute(typeof(Cognology.FlightBookingApp.Startup))]
namespace Cognology.FlightBookingApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            HttpConfiguration configuration = new HttpConfiguration();

            Bootstrapper.Init(configuration);
        }
    }
}
