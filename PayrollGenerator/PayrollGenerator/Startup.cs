using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PayrollGenerator.Startup))]
namespace PayrollGenerator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
