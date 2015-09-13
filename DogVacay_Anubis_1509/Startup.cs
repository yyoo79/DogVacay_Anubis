using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DogVacay_Anubis_1509.Startup))]
namespace DogVacay_Anubis_1509
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
