using System.Web.Http;
using Cognology.FlightBookingApp;
using WebActivatorEx;
using Swashbuckle.Application;
using System;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Cognology.FlightBookingApp
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            Swashbuckle.Bootstrapper.Init(GlobalConfiguration.Configuration);

            // NOTE: If you want to customize the generated swagger or UI, use SwaggerSpecConfig and/or SwaggerUiConfig here ...
            SwaggerSpecConfig.Customize(c => c.IncludeXmlComments(GetXmlComments()));
        }

        private static string GetXmlComments()
        {
            return String.Format(@"{0}\bin\Cognology.FlightBookingApp.XML", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}