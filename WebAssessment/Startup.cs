using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAssessment.Startup))]
namespace WebAssessment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
