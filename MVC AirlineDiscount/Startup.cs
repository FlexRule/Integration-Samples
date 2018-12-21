using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirlineDiscount.Startup))]
namespace AirlineDiscount
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
